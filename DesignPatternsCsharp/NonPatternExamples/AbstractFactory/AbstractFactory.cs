
namespace Learn_DesignPatterns.NonPatternExamples.AbstractFactory
{
    public class AbstractFactory
    {
        public static void Run()
        {
            ProductCreator google = new GoogleProductCreator();
            ProductCreator microsoft = new MicrosoftProductCreator();

            IDocument googleDoc = google.CreateDocument("D");
            IDocument googleSheet = google.CreateDocument("X");

            IDocument word = microsoft.CreateDocument("D");
            IDocument excel = microsoft.CreateDocument("X");
        }
    }

    public abstract class ProductCreator
    {
        public abstract IDocument CreateDocument(string type);
    }

    public class GoogleProductCreator : ProductCreator
    {
        public override IDocument CreateDocument(string type)
        {
            IDocument document = null;
            if (type == "D")
            {
                document = new GoogleDoc();
            }
            else if (type == "X")
            {
                document = new GoogleSheet();
            }
            return document;
        }
    }

    public class MicrosoftProductCreator : ProductCreator
    {
        public override IDocument CreateDocument(string type)
        {
            IDocument document = null;
            if (type == "D")
            {
                document = new MicrosoftWord();
            }
            else if (type == "X")
            {
                document = new MicrosoftExcel();
            }
            return document;
        }
    }

    public interface IDocument
    {
        void Create();
    }

    public class GoogleDoc : IDocument
    {
        public void Create()
        {
            Console.WriteLine("Create google doc");
        }
    }

    public class GoogleSheet : IDocument
    {
        public void Create()
        {
            Console.WriteLine("Create google sheet");
        }
    }

    public class MicrosoftWord : IDocument
    {
        public void Create()
        {
            Console.WriteLine("Create microsoft word");
        }
    }

    public class MicrosoftExcel : IDocument
    {
        public void Create()
        {
            Console.WriteLine("Create microsoft excel");
        }
    }
}
