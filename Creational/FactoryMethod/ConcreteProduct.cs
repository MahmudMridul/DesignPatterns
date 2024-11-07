
namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    public interface IDocument
    {
        void Open();
        void Save();
        void Close();
    }

    public class Pdf : IDocument
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

    public class Word : IDocument
    {
        public void Close()
        {
            Console.WriteLine("Close word doc");
        }

        public void Open()
        {
            Console.WriteLine("Open word doc");
        }

        public void Save()
        {
            Console.WriteLine("Save word doc");
        }
    }
}
