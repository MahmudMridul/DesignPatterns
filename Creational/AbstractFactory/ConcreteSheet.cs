
namespace Learn_DesignPatterns.Creational.AbstractFactory
{
    public interface ISheet
    {
        void Create();
    }

    public class GoogleSheet : ISheet
    {
        public void Create()
        {
            Console.WriteLine("Create google sheet");
        }
    }

    public class MicrosoftExcel : ISheet
    {
        public void Create()
        {
            Console.WriteLine("Create microsoft excel");
        }
    }
}
