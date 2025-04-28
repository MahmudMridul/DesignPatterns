
namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    public class PdfFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new Pdf();
        }
    }

    public class WordFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new Word();
        }
    }
}
