using Application.Interfaces.Services;

namespace Application.Services
{
    public class XMLGeneratorService : IXMLGeneratorService
    {
        public void GetXMLFromObject(StreamWriter writer, object o)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(o.GetType());
            x.Serialize(writer, o);
        }
    }
}
