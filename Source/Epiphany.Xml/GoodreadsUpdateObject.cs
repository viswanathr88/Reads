using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("object")]
    public class GoodreadsUpdateObject
    {
        [XmlElement("read_status")]
        public GoodreadsReadStatus ReadStatus
        {
            get;
            set;
        }

        [XmlElement("book")]
        public GoodreadsBook Book
        {
            get;
            set;
        }

        [XmlElement("user_status")]
        public GoodreadsUserStatus UserStatus
        {
            get;
            set;
        }
    }
}
