
namespace Learn_DesignPatterns.Structural.Adapter
{
    // Target: Existing interface client expects
    public interface IJsonAdapter
    {
        string GetJsonData();
    }

    // Adaptee: Legacy system that needs to be adapted
    public class LegacyXmlSystem
    {
        public string GetXmlData()
        {
            return "<data> some XML data </data>";
        }
    }

    // Adapter: Adapter implementation
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
