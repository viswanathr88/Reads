using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("group_user")]
    public class GoodreadsGroupUser
    {
        [XmlElement("title")]
        public string Title
        {
            get;
            set;
        }

        [XmlElement("comments_count")]
        public string CommentsCount
        {
            get;
            set;
        }

        [XmlElement("user")]
        public GoodreadsGroupSubUser User
        {
            get;
            set;
        }
    }
}
