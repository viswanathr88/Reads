using System.Collections.Generic;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("review")]
    public class GoodreadsReview
    {
        [XmlElement("id")]
        public int Id
        {
            get;
            set;
        }

        [XmlElement("rating")]
        public string Rating
        {
            get;
            set;
        }

        [XmlElement("votes")]
        public string Votes
        {
            get;
            set;
        }

        [XmlElement("user")]
        public GoodreadsUser User
        {
            get;
            set;
        }

        [XmlElement("spoiler_flag")]
        public string IsSpoiler
        {
            get;
            set;
        }

        [XmlElement("spoiler_state")]
        public string SpoilerState
        {
            get;
            set;
        }

        [XmlArray("shelves")]
        [XmlArrayItem("shelf")]
        public List<GoodreadsShelf> Shelves
        {
            get;
            set;
        }

        [XmlElement("recommended_for")]
        public string RecommendedFor
        {
            get;
            set;
        }

        [XmlElement("recommended_by")]
        public string RecommendedBy
        {
            get;
            set;
        }

        [XmlElement("started_at")]
        public string StartedAt
        {
            get;
            set;
        }

        [XmlElement("read_at")]
        public string ReadAt
        {
            get;
            set;
        }

        [XmlElement("date_added")]
        public string DateAdded
        {
            get;
            set;
        }

        [XmlElement("date_updated")]
        public string DateUpdated
        {
            get;
            set;
        }

        [XmlElement("read_count")]
        public string ReadCount
        {
            get;
            set;
        }

        [XmlElement("body")]
        public string Body
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

        [XmlElement("url")]
        public string Url
        {
            get;
            set;
        }

        [XmlElement("link")]
        public string Link
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

        [XmlArray("read_statuses")]
        [XmlArrayItem("read_status")]
        public List<GoodreadsReadStatus> ReadStatuses
        {
            get;
            set;
        }
    }
}
