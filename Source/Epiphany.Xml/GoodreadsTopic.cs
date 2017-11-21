using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("topic")]
    public class GoodreadsTopic
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("author_user_id")]
        public string AuthorUserId
        {
            get;
            set;
        }

        [XmlElement("author_user_name")]
        public string AuthorUsername
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

        [XmlElement("new_comments_count")]
        public string NewCommentsCount
        {
            get;
            set;
        }

        [XmlElement("comments_per_page")]
        public string CommentsPerPage
        {
            get;
            set;
        }

        [XmlElement("title")]
        public string Title
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

        [XmlElement("last_comment_at")]
        public string LastCommentAt
        {
            get;
            set;
        }

        [XmlElement("subject_type")]
        public string SubjectType
        {
            get;
            set;
        }

        [XmlElement("folder")]
        public GoodreadsGroupFolder Folder
        {
            get;
            set;
        }

        [XmlElement("subscription_frequency")]
        public string SubscriptionFrequency
        {
            get;
            set;
        }

        [XmlElement("is_member")]
        public string IsMember
        {
            get;
            set;
        }

        [XmlElement("group_subscription_frequency")]
        public string GroupSubscriptionFrequency
        {
            get;
            set;
        }

        [XmlElement("group")]
        public GoodreadsGroup Group
        {
            get;
            set;
        }

        [XmlElement("comments")]
        public GoodreadsComments Comments
        {
            get;
            set;
        }
    }
}
