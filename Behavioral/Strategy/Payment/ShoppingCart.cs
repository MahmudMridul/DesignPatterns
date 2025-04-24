
namespace Learn_DesignPatterns.Behavioral.Strategy.Payment
{
    public class ShoppingCart
    {
        private IPaymentStrategy _paymentStrategy;
        private decimal _totalAmount;

        public ShoppingCart(IPaymentStrategy strategy)
        {
            _paymentStrategy = strategy;
        }

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _paymentStrategy = strategy;
        }

        public bool Checkout()
        {
            return _paymentStrategy.Pay(_totalAmount);
        }
    }
}
