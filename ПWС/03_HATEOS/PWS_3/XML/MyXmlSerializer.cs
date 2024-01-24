using Newtonsoft.Json;

namespace PWS_3.XML
{
    public static class MyXmlSerializer
    {
        public static string Serialize(object response)
        {
            var jsonTest = JsonConvert.SerializeObject(response);
            
            var xmlTest = JsonConvert.DeserializeXmlNode(jsonTest, "root");

            return xmlTest.OuterXml;
        }
        
    }
}