namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class WordFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new Word();
        }
    }
}
