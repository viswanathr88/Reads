using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("user_status")]
    public class GoodreadsUserStatus
    {
        [XmlElement("body")]
        public string Body
        {
            get;
            set;
        }

        [XmlElement("chapter")]
        public string Chapter
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

        [XmlElement("created_at")]
        public string CreatedAt
        {
            get;
            set;
        }

        [XmlElement("id")]
        public int Id
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

        [XmlElement("note_updated_at")]
        public string NoteUpdatedAt
        {
            get;
            set;
        }

        [XmlElement("note_uri")]
        public string NoteUri
        {
            get;
            set;
        }

        [XmlElement("page")]
        public string Page
        {
            get;
            set;
        }

        [XmlElement("percent")]
        public string Percent
        {
            get;
            set;
        }

        [XmlElement("ratings_count")]
        public string RatingsCount
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

        [XmlElement("work_id")]
        public string WorkId
        {
            get;
            set;
        }

        [XmlElement("review_id")]
        public string ReviewId
        {
            get;
            set;
        }

        [XmlElement("book")]
        public GoodreadsBook Book
        {
            get;
            set;
        }
    }
}
