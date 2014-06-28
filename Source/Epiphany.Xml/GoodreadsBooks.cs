using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("books")]
    public class GoodreadsBooks : IPartialCollection<GoodreadsBook>
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

        [XmlElement("book")]
        public GoodreadsBook[] Items
        {
            get;
            set;
        }
    }
}
