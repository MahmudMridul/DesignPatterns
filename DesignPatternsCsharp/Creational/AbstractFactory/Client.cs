
namespace Learn_DesignPatterns.Creational.AbstractFactory
{
    public class Client
    {
        public static void Run()
        {
            ProductCreator goolge = new GoogleProductCreator();
            ProductCreator microsoft = new MicrosoftProductCreator();

            IWord googleDoc = goolge.CreateWord();
            ISheet excel = microsoft.CreateSheet();
        }
    }
}
