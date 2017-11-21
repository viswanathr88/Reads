using System.Collections.Generic;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("group")]
    public class GoodreadsGroup
    {
        [XmlElement("id")]
        public long Id
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

        [XmlElement("description")]
        public string Description
        {
            get;
            set;
        }

        [XmlElement("access")]
        public string Access
        {
            get;
            set;
        }

        [XmlElement("location")]
        public string Location
        {
            get;
            set;
        }

        [XmlElement("last_activity_at")]
        public string LastActivityAt
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

        [XmlElement("subscription_frequency")]
        public string SubscriptionFrequency
        {
            get;
            set;
        }

        [XmlElement("display_folder_count")]
        public string DisplayFolderCount
        {
            get;
            set;
        }

        [XmlElement("display_topics_per_folder")]
        public string DisplayTopicsPerFolder
        {
            get;
            set;
        }

        [XmlElement("bookshelves_public_flag")]
        public string AreBookshelvesPublic
        {
            get;
            set;
        }

        [XmlElement("add_books_flag")]
        public string CanAddBooks
        {
            get;
            set;
        }

        [XmlElement("add_events_flag")]
        public string CanAddEvents
        {
            get;
            set;
        }

        [XmlElement("polls_flag")]
        public string CanHavePolls
        {
            get;
            set;
        }

        [XmlElement("discussion_public_flag")]
        public string AreDiscussionsPublic
        {
            get;
            set;
        }

        [XmlElement("real_world_flag")]
        public string IsRealWorld
        {
            get;
            set;
        }

        [XmlElement("accepting_new_members")]
        public string AcceptsNewMembers
        {
            get;
            set;
        }

        [XmlElement("category")]
        public string Organizations
        {
            get;
            set;
        }

        [XmlElement("subcategory")]
        public string SubCategory
        {
            get;
            set;
        }

        [XmlElement("rules")]
        public string Rules
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

        [XmlElement("image_url")]
        public string ImageUrl
        {
            get;
            set;
        }

        [XmlElement("group_users_count")]
        public string UsersCount
        {
            get;
            set;
        }

        [XmlArray("folders")]
        [XmlArrayItem("folder")]
        public List<GoodreadsGroupFolder> Folders
        {
            get;
            set;
        }

        [XmlArray("moderators")]
        [XmlArrayItem("group_user")]
        public List<GoodreadsGroupUser> Moderators
        {
            get;
            set;
        }

        [XmlArray("members")]
        [XmlArrayItem("group_user")]
        public List<GoodreadsGroupUser> Members
        {
            get;
            set;
        }
    }
}
