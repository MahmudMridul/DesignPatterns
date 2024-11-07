
namespace Learn_DesignPatterns.Creational.AbstractFactory
{
    public interface IWord
    {
        void Create();
    }

    public class GoogleDoc : IWord
    {
        public void Create()
        {
            Console.WriteLine("Create google doc");
        }
    }

    public class MicrosoftWord : IWord
    {
        public void Create()
        {
            Console.WriteLine("Create microsoft word");
        }
    }
}
