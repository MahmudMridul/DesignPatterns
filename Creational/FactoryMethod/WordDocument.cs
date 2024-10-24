namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class WordDocument : IDocument
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
