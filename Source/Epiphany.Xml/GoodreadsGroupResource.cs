using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("group_resource")]
    public class GoodreadsGroupResource
    {
        [XmlElement("review")]
        public GoodreadsReview Review
        {
            get;
            set;
        }

        [XmlElement("read_status")]
        public GoodreadsReadStatus ReadStatus
        {
            get;
            set;
        }

        [XmlElement("friend")]
        public GoodreadsFriend Friend
        {
            get;
            set;
        }

        [XmlElement("user_status")]
        public GoodreadsUserStatus UserStatus
        {
            get;
            set;
        }

        [XmlElement("topic")]
        public GoodreadsTopic Topic
        {
            get;
            set;
        }

        [XmlElement("user_following")]
        public GoodreadsUserFollowing UserFollowing
        {
            get;
            set;
        }
    }
}
