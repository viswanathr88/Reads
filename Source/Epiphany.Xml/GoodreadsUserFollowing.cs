using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("user_following")]
    public class GoodreadsUserFollowing
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("user_id")]
        public string UserId
        {
            get;
            set;
        }

        [XmlElement("follower_id")]
        public string FollowerId
        {
            get;
            set;
        }

        [XmlElement("created_at")]
        public string CreatedAt
        {
            get;
            set;
        }
    }
}
