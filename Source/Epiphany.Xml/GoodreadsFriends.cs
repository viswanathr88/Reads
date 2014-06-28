using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("friends")]
    public class GoodreadsFriends : IPartialCollection<GoodreadsUser>
    {
        [XmlAttribute("start")]
        public string Start
        {
            get;
            set;
        }

        [XmlAttribute("end")]
        public string End
        {
            get;
            set;
        }

        [XmlAttribute("total")]
        public string Total
        {
            get;
            set;
        }

        [XmlElement("user")]
        public GoodreadsUser[] Items
        {
            get;
            set;
        }
    }
}
