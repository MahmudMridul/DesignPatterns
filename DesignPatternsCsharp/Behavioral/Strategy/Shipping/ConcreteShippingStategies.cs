
using Learn_DesignPatterns.NonPatternExamples.Strategy;

namespace Learn_DesignPatterns.Behavioral.Strategy.Shipping
{
    public interface IShippingStrategy
    {
        decimal CalculateShipping(Order order);
    }

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
}
