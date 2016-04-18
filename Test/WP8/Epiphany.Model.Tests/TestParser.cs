using Epiphany.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Epiphany.Model.Tests
{
    public static class TestParser
    {
        public static Response GetResponse(Stream stream)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Response));
            return (Response)serializer.ReadObject(stream);
        }

        public static Response ParseXml(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Response));
            return (Response)serializer.Deserialize(stream);
        }
    }
}
