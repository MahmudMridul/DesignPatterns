
namespace Learn_DesignPatterns.Structural.Adapter
{
    public interface IJsonAdapter
    {
        string GetJsonData();
    }

    public class LegacyXmlSystem
    {
        public string GetXmlData()
        {
            return "<data> some XML data </data>";
        }
    }

    public class  XmlToJsonAdapter : IJsonAdapter
    {
        private LegacyXmlSystem _xmlSystem;

        public XmlToJsonAdapter(LegacyXmlSystem xmlSystem)
        {
            _xmlSystem = xmlSystem;
        }

        public string GetJsonData()
        {
            string xmlData = _xmlSystem.GetXmlData();
            // converting xml to json
            return "{ data: some XML data converted to JSON }";
        }
    }
}
