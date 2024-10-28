
namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class Pdf : IDocument
    {
        public void Close()
        {
            Console.WriteLine("Close PDF");
        }

        public void Open()
        {
            Console.WriteLine("Open PDF");
        }

        public void Save()
        {
            Console.WriteLine("Save PDF");
        }
    }
}
