
using Learn_DesignPatterns.NonPatternExamples.Strategy;

namespace Learn_DesignPatterns.Behavioral.Strategy.Shipping
{
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

}
