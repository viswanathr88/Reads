using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("topics")]
    public class GoodreadsTopics : IPartialCollection<GoodreadsTopic>
    {
        [XmlElement("start")]
        public string Start
        {
            get;
            set;
        }

        [XmlElement("end")]
        public string End
        {
            get;
            set;
        }

        [XmlElement("total")]
        public string Total
        {
            get;
            set;
        }

        [XmlElement("topic")]
        public GoodreadsTopic[] Items
        {
            get;
            set;
        }
    }
}
