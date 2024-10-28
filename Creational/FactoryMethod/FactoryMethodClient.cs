namespace Learn_DesignPatterns.Creational.FactoryMethod
{
    internal class FactoryMethodClient
    {
        public void Run()
        {
            DocumentFactory pdfFactory = new PdfFactory();
            DocumentFactory wordFactory = new WordFactory();

            IDocument pdf = pdfFactory.CreateDocument();
            IDocument word = wordFactory.CreateDocument();

            pdf.Open();
            word.Open();

            pdf.Close();
            word.Close();
        }
    }
}
