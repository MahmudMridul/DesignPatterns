
namespace Learn_DesignPatterns.NonPatternExamples.Strategy
{
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
}
