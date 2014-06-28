using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("events")]
    public class GoodreadsEvents
    {
        [XmlElement("event")]
        public GoodreadsEvent[] Events
        {
            get;
            set;
        }
    }
}
