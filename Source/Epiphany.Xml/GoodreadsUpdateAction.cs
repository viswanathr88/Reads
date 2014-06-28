using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("action")]
    public class GoodreadsUpdateAction
    {
        [XmlAttribute("type")]
        public string Type
        {
            get;
            set;
        }

        [XmlElement("rating")]
        public string Rating
        {
            get;
            set;
        }
    }
}
