using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("friend")]
    public class GoodreadsFriend
    {
        [XmlElement("id")]
        public int Id
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

        [XmlElement("created_at")]
        public string CreatedAt
        {
            get;
            set;
        }

        [XmlElement("friend_approved_at")]
        public string FriendApprovedAt
        {
            get;
            set;
        }

        [XmlElement("relationship")]
        public string Relationship
        {
            get;
            set;
        }

        [XmlElement("story")]
        public string Story
        {
            get;
            set;
        }

        [XmlElement("updated_at")]
        public string UpdatedAt
        {
            get;
            set;
        }

        [XmlElement("updates_flag")]
        public string UpdatesFlag
        {
            get;
            set;
        }

        [XmlElement("user_approved_at")]
        public string UserApprovedAt
        {
            get;
            set;
        }
    }
}
