
namespace Learn_DesignPatterns.Creational.AbstractFactory
{
    public abstract class ProductCreator
    {
        public abstract ISheet CreateSheet();
        public abstract IWord CreateWord();
    }

    public class GoogleProductCreator : ProductCreator
    {
        public override ISheet CreateSheet()
        {
            return new GoogleSheet();
        }

        public override IWord CreateWord()
        {
            return new GoogleDoc();
        }
    }

    public class MicrosoftProductCreator : ProductCreator
    {
        public override ISheet CreateSheet()
        {
            return new MicrosoftExcel();
        }

        public override IWord CreateWord()
        {
            return new MicrosoftWord();
        }
    }
}
