using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("comments")]
    public class GoodreadsComments : IPartialCollection<GoodreadsComment>
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

        [XmlElement("comment")]
        public GoodreadsComment[] Items
        {
            get;
            set;
        }
    }
}
