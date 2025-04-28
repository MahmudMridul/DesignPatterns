namespace Learn_DesignPatterns.Structural.Adapter
{
    public class AdapterClient
    {
        public void Run()
        {
            LegacyXmlSystem xmlSystem = new LegacyXmlSystem();
            IJsonAdapter adapter = new XmlToJsonAdapter(xmlSystem);
            string jsonData = adapter.GetJsonData();
            Console.WriteLine(jsonData);
        }
    }
}
