# Strategy Design Pattern

## Introduction
The Strategy Design Pattern is a behavioral design pattern that enables selecting an algorithm's behavior at runtime. Rather than implementing a single algorithm directly, code receives run-time instructions as to which algorithm to use.

Think of it like choosing different routes to get to work: walking, driving, or taking public transport. Each "strategy" achieves the same goal (getting to work) but uses a different approach. Instead of hardcoding your commute method, you can switch between strategies based on weather, time constraints, or other factors.

## Pattern Classification
- **Type**: Behavioral
- **Scope**: Object

## Problem Statement
Software often needs to support multiple ways of performing the same task. Without a proper pattern, this leads to:

- Conditional logic (if/else or switch statements) scattered throughout the code
- Difficulty adding new algorithms without modifying existing code
- Code that violates the Open/Closed Principle
- Tight coupling between the client code and the specific algorithms
- Challenges in unit testing individual algorithms separately

For example, consider a payment processing system that must support multiple payment methods. Traditional approaches might use complex conditional branches that become increasingly difficult to maintain as more payment options are added.

## Anti-Pattern Case Study
Here's an example of code that doesn't use the Strategy pattern but should:

```csharp
public class ShippingCalculator
{
    public decimal CalculateShipping(Order order, string shippingMethod)
    {
        decimal shippingCost = 0;

        switch (shippingMethod)
        {
            case "Standard":
                // Standard shipping calculation
                shippingCost = order.Weight * 1.5m;
                if (order.Weight > 10)
                {
                    shippingCost *= 0.9m; // 10% discount for heavy items
                }
                break;

            case "Express":
                // Express shipping calculation
                shippingCost = order.Weight * 3.0m;
                if (order.TotalAmount > 100)
                {
                    shippingCost -= 5; // $5 off for orders over $100
                }
                break;

            case "NextDay":
                // Next day shipping calculation
                shippingCost = order.Weight * 4.5m;
                if (order.Distance > 100)
                {
                    shippingCost += 10; // $10 surcharge for long distances
                }
                break;

            default:
                throw new ArgumentException("Unsupported shipping method");
        }

        return shippingCost;
    }
}

// Supporting class for the example
public class Order
{
    public decimal Weight { get; set; }
    public decimal TotalAmount { get; set; }
    public int Distance { get; set; }
}
```

This implementation has several problems:
- Adding a new shipping method requires modifying existing code
- The class violates the Single Responsibility Principle by handling multiple algorithms
- If the calculation logic needs to be reused elsewhere, it cannot be easily extracted
- As more shipping methods are added, the switch statement grows unwieldy

Over time, these issues compound. When business requirements change (e.g., adding regional shipping rules or promotional discounts), the code becomes increasingly complex and error-prone. Refactoring might require changes throughout the application, leading to potential regressions.

## Solution
The Strategy pattern addresses these issues by:
1. Defining a family of algorithms (strategies)
2. Encapsulating each algorithm in separate classes
3. Making the algorithms interchangeable within that family

The pattern consists of:
- **Strategy Interface**: Defines the common interface for all concrete strategies
- **Concrete Strategies**: Implement the algorithm using the strategy interface
- **Context**: Maintains a reference to a strategy object and delegates to it

## Implementation in `C#`

```csharp
// Step 1: Define the strategy interface
public interface IShippingStrategy
{
    decimal CalculateShipping(Order order);
}

// Step 2: Implement concrete strategies
public class StandardShippingStrategy : IShippingStrategy
{
    public decimal CalculateShipping(Order order)
    {
        decimal cost = order.Weight * 1.5m;
        if (order.Weight > 10)
            cost *= 0.9m; // 10% discount for heavy items
        return cost;
    }
}

public class ExpressShippingStrategy : IShippingStrategy
{
    public decimal CalculateShipping(Order order)
    {
        decimal cost = order.Weight * 3.0m;
        if (order.TotalAmount > 100)
            cost -= 5; // $5 off for orders over $100
        return cost;
    }
}

public class NextDayShippingStrategy : IShippingStrategy
{
    public decimal CalculateShipping(Order order)
    {
        decimal cost = order.Weight * 4.5m;
        if (order.Distance > 100)
            cost += 10; // $10 surcharge for long distances
        return cost;
    }
}

// Step 3: Create the context class
public class ShippingCalculator
{
    private IShippingStrategy _strategy;

    public ShippingCalculator(IShippingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IShippingStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculateShipping(Order order)
    {
        return _strategy.CalculateShipping(order);
    }
}
```

## Step-by-Step Breakdown

1. We define the `IShippingStrategy` interface with a single method `CalculateShipping` that takes an order and returns the shipping cost.

2. We implement three concrete strategies (`StandardShippingStrategy`, `ExpressShippingStrategy`, and `NextDayShippingStrategy`), each with its own algorithm for calculating shipping costs.

3. We create a `ShippingCalculator` context class that:
   - Takes a strategy in its constructor
   - Provides a method to change the strategy at runtime
   - Delegates the actual calculation to the current strategy

4. This approach separates the calculation algorithms from the context that uses them, making the system much more flexible and maintainable.

## Usage Examples

```csharp
// Create an order
var order = new Order
{
    Weight = 15,
    TotalAmount = 150,
    Distance = 120
};

var standardShipping = new StandardShippingStrategy();
var expressShipping = new ExpressShippingStrategy();
var nextDayShipping = new NextDayShippingStrategy();

var calculator = new ShippingCalculator(standardShipping);

decimal standardCost = calculator.CalculateShipping(order);
Console.WriteLine($"Standard shipping cost: ${standardCost}");

calculator.SetStrategy(expressShipping);
decimal expressCost = calculator.CalculateShipping(order);
Console.WriteLine($"Express shipping cost: ${expressCost}");

calculator.SetStrategy(nextDayShipping);
decimal nextDayCost = calculator.CalculateShipping(order);
Console.WriteLine($"Next day shipping cost: ${nextDayCost}");

// we can also create a factory to get the appropriate strategy:
public static IShippingStrategy GetShippingStrategy(string method)
{
    return method switch
    {
        "Standard" => new StandardShippingStrategy(),
        "Express" => new ExpressShippingStrategy(),
        "NextDay" => new NextDayShippingStrategy(),
        _ => throw new ArgumentException("Unsupported shipping method")
    };
}

// And use it like this:
calculator.SetStrategy(GetShippingStrategy("Express"));
```

## Advantages

- **Open/Closed Principle**: You can add new strategies without modifying existing code
- **Single Responsibility Principle**: Each strategy encapsulates its own algorithm
- **Improved Testability**: Strategies can be tested independently
- **Runtime Flexibility**: Algorithms can be switched during runtime
- **Elimination of Conditional Logic**: Reduces or eliminates complex if/else or switch statements
- **Code Reuse**: Strategies can be reused across different contexts
- **Maintainability**: Easier to understand and maintain multiple simple classes than one complex class

## Disadvantages and Limitations

- **Increased Number of Classes**: Creates more classes, which can add complexity
- **Client Must Be Aware of Strategies**: The client must know which strategy to select
- **Communication Overhead**: Strategies might need data from the context, requiring parameter passing
- **Overkill for Simple Cases**: May be unnecessary for applications with only one or two simple algorithms
- **Memory Usage**: Additional objects are created, which might impact performance in memory-constrained environments

## Related Patterns
- **Factory Method**: Often used with Strategy to instantiate the appropriate strategy

## Best Practices and Tips

- Use dependency injection to provide strategies to the context
- Consider using a factory method to create strategies
- Keep the strategy interface focused and cohesive
- Ensure strategies have access to all the data they need to function
- Use default strategies when appropriate
- Document the behavior of each strategy clearly
- Consider making strategies stateless to improve reusability

## Conclusion

The Strategy Design Pattern is a powerful tool for managing algorithms, behaviors, or processes that need to vary independently from clients that use them. By encapsulating different algorithms in separate classes with a common interface, it promotes code that is more maintainable, extensible, and adheres to SOLID principles.

When you find yourself writing complex conditional logic to choose between different algorithms or behaviors, consider the Strategy pattern. It's particularly valuable in systems that need to support multiple ways of performing the same task, especially when those algorithms need to be selected at runtime or are likely to change over time.