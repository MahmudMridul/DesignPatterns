namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
}
