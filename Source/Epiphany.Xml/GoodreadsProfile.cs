using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("user")]
    public class GoodreadsProfile
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("name")]
        public string Name
        {
            get;
            set;
        }

        [XmlElement("user_name")]
        public string Username
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

        [XmlElement("small_image_url")]
        public string SmallImageUrl
        {
            get;
            set;
        }

        [XmlElement("is_following")]
        public string IsFollowing
        {
            get;
            set;
        }

        [XmlElement("about")]
        public string About
        {
            get;
            set;
        }

        [XmlElement("age")]
        public string Age
        {
            get;
            set;
        }

        [XmlElement("gender")]
        public string Gender
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

        [XmlElement("website")]
        public string Website
        {
            get;
            set;
        }

        [XmlElement("joined")]
        public string JoinDate
        {
            get;
            set;
        }

        [XmlElement("last_active")]
        public string LastActive
        {
            get;
            set;
        }

        [XmlElement("interests")]
        public string Interests
        {
            get;
            set;
        }

        [XmlElement("favorite_books")]
        public string FavoriteBooks
        {
            get;
            set;
        }

        [XmlArray("favorite_authors")]
        [XmlArrayItem("author")]
        public List<GoodreadsAuthor> FavoriteAuthors
        {
            get;
            set;
        }

        [XmlElement("friend")]
        public string IsFriend
        {
            get;
            set;
        }

        [XmlElement("friend_status")]
        public string FriendStatus
        {
            get;
            set;
        }

        [XmlElement("updates_rss_url")]
        public string UpdatesRssUrl
        {
            get;
            set;
        }

        [XmlElement("reviews_rss_url")]
        public string ReviewsRssUrl
        {
            get;
            set;
        }

        [XmlElement("friends_count")]
        public string FriendsCount
        {
            get;
            set;
        }

        [XmlElement("groups_count")]
        public string GroupsCount
        {
            get;
            set;
        }

        [XmlElement("reviews_count")]
        public string ReviewsCount
        {
            get;
            set;
        }

        [XmlArray("user_shelves")]
        [XmlArrayItem("user_shelf")]
        public List<GoodreadsUserShelf> Shelves
        {
            get;
            set;
        }

        [XmlArray("updates")]
        [XmlArrayItem("update")]
        public List<GoodreadsUpdate> Updates
        {
            get;
            set;
        }

        [XmlArray("user_statuses")]
        [XmlArrayItem("user_status")]
        public List<GoodreadsUserStatus> UserStatuses
        {
            get;
            set;
        }
    }
}
