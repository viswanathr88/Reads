using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("user")]
    public class GoodreadsGroupSubUser
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("first_name")]
        public string FirstName
        {
            get;
            set;
        }

        [XmlElement("last_name")]
        public string LastName
        {
            get;
            set;
        }

        [XmlElement("user_name")]
        public string Username
        {
            get;
            set;
        }

        [XmlElement("p2_image_url")]
        public string ImageUrl
        {
            get;
            set;
        }
    }
}
