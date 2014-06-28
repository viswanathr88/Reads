using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("list")]
    public class GoodreadsGroupList : IPartialCollection<GoodreadsGroup>
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

        [XmlElement("group")]
        public GoodreadsGroup[] Items
        {
            get;
            set;
        }
    }
}
