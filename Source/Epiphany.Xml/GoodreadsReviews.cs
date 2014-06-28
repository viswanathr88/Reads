using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("reviews")]
    public class GoodreadsReviews : IPartialCollection<GoodreadsReview>
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

        [XmlElement("review")]
        public GoodreadsReview[] Items
        {
            get;
            set;
        }
    }
}
