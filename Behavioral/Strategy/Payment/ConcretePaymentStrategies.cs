
namespace Learn_DesignPatterns.Behavioral.Strategy.Payment
{
    public interface IPaymentStrategy
    {
        public bool Pay(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        private readonly string _cardNumber;
        private readonly string _name;
        private readonly string _cvv;
        private readonly string _dateOfExpiry;

        public CreditCardPayment(string cardNumber, string name, string cvv, string dateOfExpiry)
        {
            _cardNumber = cardNumber;
            _name = name;
            _cvv = cvv;
            _dateOfExpiry = dateOfExpiry;
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Paying ${amount} using Credit Card");
            Console.WriteLine($"Credit Card Details: {_cardNumber}");
            // Process payment with payment gateway
            return true;
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        private readonly string _email;
        private readonly string _password;

        public PayPalPayment(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Paying ${amount} using PayPal");
            Console.WriteLine($"PayPal account: {_email}");
            // Process payment with PayPal API
            return true;
        }
    }

    public class CryptocurrencyPayment : IPaymentStrategy
    {
        private readonly string _walletAddress;

        public CryptocurrencyPayment(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Paying ${amount} using Cryptocurrency");
            Console.WriteLine($"Wallet Address: {_walletAddress}");
            // Process payment through blockchain
            return true;
        }

    }
}
