using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("comment")]
    public class GoodreadsComment
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("body")]
        public string Body
        {
            get;
            set;
        }

        [XmlElement("updated_at")]
        public string UpdatedAt
        {
            get;
            set;
        }

        [XmlElement("user")]
        public GoodreadsUser User
        {
            get;
            set;
        }
    }
}
