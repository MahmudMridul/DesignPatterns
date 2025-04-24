
namespace Learn_DesignPatterns.Behavioral.Strategy.Payment
{
    public class ECommerceApp
    {
        public static void Run()
        {
            IPaymentStrategy creditCard = new CreditCardPayment("1234", "name", "123", "2030-12-31");
            IPaymentStrategy paypal = new PayPalPayment("example@example.com", "strongPassowrd");
            IPaymentStrategy crypto = new CryptocurrencyPayment("123456");

            ShoppingCart cart = new ShoppingCart(creditCard);
            
            // user selects payment method
            int selection = 1;

            switch (selection)
            {
                case 1:
                    cart.SetPaymentStrategy(creditCard);
                    break;
                case 2:
                    cart.SetPaymentStrategy(paypal);
                    break;
                case 3:
                    cart.SetPaymentStrategy(crypto);
                    break;
                default:
                    break;
            }
            cart.Checkout();
        }
    }
}
