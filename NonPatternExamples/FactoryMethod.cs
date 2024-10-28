namespace Learn_DesignPatterns.NonPatternExamples
{
    public class Client
    {
        public static void ClientMain()
        {
            DocumentCreator creator = new DocumentCreator();
            Document pdf = creator.CreateDocument("pdf");
            Document word = creator.CreateDocument("word");
        }
    }

    public class DocumentCreator
    {
        public Document CreateDocument(string type)
        {
            Document doc = null!;
            if (type == "pdf")
            {
                doc = new Pdf();
            }
            else if (type == "word")
            {
                doc = new Word();
            }
            return doc;
        }
    }

    public interface Document
    {
        void Open();
        void Close();
        void Save();
    }

    public class Pdf : Document
    {
        public void Open()
        {
            //logic
        }

        public void Close()
        {
            //logic
        }
        public void Save()
        {
            //logic
        }
    }

    public class Word : Document
    {
        public void Open()
        {
            //logic
        }

        public void Close()
        {
            //logic
        }
        public void Save()
        {
            //logic
        }
    }
}
