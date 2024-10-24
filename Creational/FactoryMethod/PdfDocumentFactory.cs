namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
}
