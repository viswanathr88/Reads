using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("GoodreadsResponse")]
    [DataContract(Name="GoodreadsResponse", Namespace="")]
    public class Response
    {
        [XmlElement("Request")]
        [DataMember]
        public Request Request
        {
            get;
            set;
        }

        [XmlElement("author")]
        [DataMember(Name="author")]
        public GoodreadsAuthor Author
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

        [XmlElement("books")]
        public GoodreadsBooks Books
        {
            get;
            set;
        }

        [XmlElement("user")]
        public GoodreadsProfile Profile
        {
            get;
            set;
        }

        [XmlElement("updates")]
        public GoodreadsUpdates Updates
        {
            get;
            set;
        }

        [XmlElement("friends")]
        public GoodreadsFriends Friends
        {
            get;
            set;
        }

        [XmlElement("shelves")]
        public GoodreadsShelves ShelfCollection
        {
            get;
            set;
        }

        [XmlElement("reviews")]
        public GoodreadsReviews Reviews
        {
            get;
            set;
        }


        [XmlElement("events")]
        public GoodreadsEvents Events
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

        [XmlElement("groups")]
        public GoodreadsGroups Groups
        {
            get;
            set;
        }

        [XmlElement("review")]
        public GoodreadsReview Review
        {
            get;
            set;
        }

        [XmlElement("group_folder")]
        public GoodreadsGroupFolder GroupFolder
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

        [XmlElement("search")]
        public GoodreadsSearch Search
        {
            get;
            set;
        }

        [XmlElement("notifications")]
        public GoodreadsNotifications Notifications
        {
            get;
            set;
        }

        [XmlElement("owned_books")]
        public GoodreadsOwnedBooks OwnedBooks
        {
            get;
            set;
        }
    }
}
