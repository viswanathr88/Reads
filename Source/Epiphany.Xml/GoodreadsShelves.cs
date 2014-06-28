using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("shelves")]
    public class GoodreadsShelves : IPartialCollection<GoodreadsUserShelf>
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

        [XmlElement("user_shelf")]
        public GoodreadsUserShelf[] Items
        {
            get;
            set;
        }
    }
}
