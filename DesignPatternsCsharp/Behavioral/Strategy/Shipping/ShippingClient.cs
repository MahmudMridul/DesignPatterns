
using Learn_DesignPatterns.NonPatternExamples.Strategy;

namespace Learn_DesignPatterns.Behavioral.Strategy.Shipping
{
    public class ShippingClient
    {
        public static void Run()
        {
            Order order = new Order()
            {
                Weight = 15,
                TotalAmount = 150,
                Distance = 120
            };

            IShippingStrategy standardShipping = new StandardShippingStrategy();
            IShippingStrategy expressShipping = new ExpressShippingStrategy();
            IShippingStrategy nextDayShipping = new NextDayShippingStrategy();

            ShippingCalculator calculator = new ShippingCalculator(standardShipping);

            decimal standardCost = calculator.CalculateShipping(order);
            Console.WriteLine($"Standard shipping cost: ${standardCost}");

            calculator.SetStrategy(expressShipping);
            decimal expressCost = calculator.CalculateShipping(order);
            Console.WriteLine($"Express shipping cost: ${expressCost}");

            calculator.SetStrategy(nextDayShipping);
            decimal nextDayCost = calculator.CalculateShipping(order);
            Console.WriteLine($"Next day shipping cost: ${nextDayCost}");

            
            calculator.SetStrategy(GetShippingStrategy("Express"));
        }

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
    }
}
