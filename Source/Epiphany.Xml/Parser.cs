using System.IO;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    public sealed class Parser
    {
        public static Response GetResponse(string xml)
        {
            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Response));
                return (Response)serializer.Deserialize(reader);
            }
        }

        public static AuthUserResponse GetAuthUserResponse(string xml)
        {
            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AuthUserResponse));
                return (AuthUserResponse)serializer.Deserialize(reader);
            }
        }
    }
}
