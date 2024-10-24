namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class FactoryMethodExecutor
    {
        public void Run()
        {
            DocumentFactory pdfFactory = new PdfDocumentFactory();
            DocumentFactory wordFactory = new WordDocumentFactory();

            IDocument pdf = pdfFactory.CreateDocument();
            IDocument word = wordFactory.CreateDocument();

            pdf.Open();
            word.Open();

            pdf.Close();
            word.Close();
        }
    }
}
