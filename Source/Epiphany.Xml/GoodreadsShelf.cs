using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("shelf")]
    public class GoodreadsShelf
    {
        [XmlElement("name")]
        public string Name
        {
            get;
            set;
        }

        [XmlElement("count")]
        public string Count
        {
            get;
            set;
        }

        [XmlAttribute("name")]
        public string Name2
        {
            get;
            set;
        }
    }
}
