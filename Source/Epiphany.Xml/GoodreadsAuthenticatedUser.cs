using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("user")]
    public class GoodreadsAuthenticatedUser
    {
        [XmlAttribute("id")]
        public string Id
        {
            get;
            set;
        }

        [XmlElement("name")]
        public string Name
        {
            get;
            set;
        }

        [XmlElement("link")]
        public string Link
        {
            get;
            set;
        }
    }
}
