namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class PdfFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new Pdf();
        }
    }
}
