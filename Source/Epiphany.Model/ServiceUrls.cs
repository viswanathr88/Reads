
namespace Epiphany.Model
{
    internal sealed class ServiceUrls
    {
        public static string AuthUserUrl
        {
            get
            {
                return "api/auth_user";
            }
        }

        public static string BookUrl
        {
            get
            {
                return "book/show";
            }
        }

        public static string AuthorUrl
        {
            get
            {
                return "author/show";
            }
        }

        public static string ProfileUrl
        {
            get
            {
                return "user/show";
            }
        }

        public static string GroupUrl
        {
            get 
            {
                return "group/show";
            }
        }

        public static string ReviewUrl
        {
            get
            {
                return "review/show";
            }
        }

        public static string TopicUrl
        {
            get
            {
                return "topic/show";
            }
        }

        public static string UserStatusUrl
        {
            get
            {
                return "user_status/show";
            }
        }

        public static string BooksInShelfUrl
        {
            get
            {
                return "review/list";
            }
        }

        public static string BooksByAuthorUrl
        {
            get
            {
                return "author/list";
            }
        }

        public static string ShelvesUrl
        {
            get
            {
                return "shelf/list";
            }
        }

        public static string GroupsUrl
        {
            get
            {
                return "groups/list";
            }
        }

        public static string AddBookUrl
        {
            get
            {
                return "shelf/add_to_shelf";
            }
        }

        public static string RemoveBookUrl
        {
            get
            {
                return "shelf/add_to_shelf";
            }
        }

        public static string AddShelfUrl
        {
            get
            {
                return "user_shelves";
            }
        }

        public static string DeleteShelfUrl
        {
            get
            {
                return "user_shelves/destroy";
            }
        }

        public static string FeedUrl
        {
            get
            {
                return "updates/friends";
            }
        }

        public static string FriendsUrl
        {
            get
            {
                return "friend/user";
            }
        }

        public static string AddFriendUrl
        {
            get
            {
                return "/friend/add_as_friend";
            }
        }

        public static string NotificationsUrl
        {
            get
            {
                return "notifications";
            }
        }

        public static string SearchUrl
        {
            get
            {
                return "search";
            }
        }

        public static string GroupFolderUrl
        {
            get
            {
                return "topic/group_folder";
            }
        }


        public static string EventsUrl
        {
            get
            {
                return "event";
            }
        }

        public static string AddReviewUrl
        {
            get
            {
                return "review";
            }
        }

        public static string LikeUrl
        {
            get
            {
                return "rating";
            }
        }

        public static string CreateTopicUrl
        {
            get
            {
                return "topic";
            }
        }

        public static string CommentCreateUrl
        {
            get
            {
                return "comment";
            }
        }

        public static string JoinGroupUrl
        {
            get
            {
                return "group/join";
            }
        }

        public static string FindGroupUrl
        {
            get
            {
                return "group/search";
            }
        }

        public static string UpdateUserStatusUrl { get; set; }
    }
}
