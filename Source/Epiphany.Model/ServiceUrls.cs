
using System;

namespace Epiphany.Model
{
    internal sealed class ServiceUrls
    {
        private static string baseUrl = @"https://www.goodreads.com/";

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
                return baseUrl + "book/show";
            }
        }

        public static string OwnedBooksUrl
        {
            get
            {
                return baseUrl + "owned_books/user";
            }
        }

        public static string AuthorUrl
        {
            get
            {
                return "author/show";
            }
        }

        public static string FollowAuthorUrl
        {
            get
            {
                return baseUrl + "author_followings";
            }
        }

        public static string ProfileUrl
        {
            get
            {
                return baseUrl + "user/show";
            }
        }

        public static string GroupUrl
        {
            get
            {
                return "group/show";
            }
        }

        public static string RecentReviewsUrl
        {
            get
            {
                return baseUrl + "review/recent_reviews.xml";
            }
        }

        public static string RecentUserStatusesUrl
        {
            get
            {
                return baseUrl + "user_status/index.xml";
            }
        }

        public static string ReviewUrl
        {
            get
            {
                return baseUrl + "review/show";
            }
        }

        public static string TopicUrl
        {
            get
            {
                return baseUrl + "topic/show";
            }
        }

        public static string UserStatusUrl
        {
            get
            {
                return baseUrl + "user_status/show";
            }
        }

        public static string BooksInShelfUrl
        {
            get
            {
                return baseUrl + "review/list";
            }
        }

        public static string BooksByAuthorUrl
        {
            get
            {
                return baseUrl + "author/list";
            }
        }

        public static string ShelvesUrl
        {
            get
            {
                return baseUrl + "shelf/list";
            }
        }

        public static string GroupsUrl
        {
            get
            {
                return baseUrl + "groups/list";
            }
        }

        public static string AddBookUrl
        {
            get
            {
                return baseUrl + "shelf/add_to_shelf";
            }
        }

        public static string RemoveBookUrl
        {
            get
            {
                // Same as add book url
                return AddBookUrl;
            }
        }

        public static string AddShelfUrl
        {
            get
            {
                return baseUrl + "user_shelves.xml";
            }
        }

        public static string DeleteShelfUrl
        {
            get
            {
                return baseUrl + "user_shelves/destroy";
            }
        }

        public static string FeedUrl
        {
            get
            {
                return baseUrl + "updates/friends.xml";
            }
        }

        public static string FriendsUrl
        {
            get
            {
                return baseUrl + "friend/user";
            }
        }

        public static string AddFriendUrl
        {
            get
            {
                return baseUrl + "friend/add_as_friend.xml";
            }
        }

        public static string NotificationsUrl
        {
            get
            {
                return baseUrl + "notifications";
            }
        }

        public static string SearchUrl
        {
            get
            {
                return @"http://www.goodreads.com/search";
            }
        }

        public static string GroupFolderUrl
        {
            get
            {
                return baseUrl + "topic/group_folder";
            }
        }


        public static string EventsUrl
        {
            get
            {
                return baseUrl + "event";
            }
        }

        public static string AddReviewUrl
        {
            get
            {
                return baseUrl + "review";
            }
        }

        public static string LikeUrl
        {
            get
            {
                return baseUrl + "rating";
            }
        }

        public static string CreateTopicUrl
        {
            get
            {
                return baseUrl + "topic";
            }
        }

        public static string CommentCreateUrl
        {
            get
            {
                return baseUrl + "comment";
            }
        }

        public static string JoinGroupUrl
        {
            get
            {
                return baseUrl + "group/join";
            }
        }

        public static string FindGroupUrl
        {
            get
            {
                return baseUrl + "group/search";
            }
        }

        public static string FollowUserUrlFormat
        {
            get
            {
                return @"http://www.goodreads.com/user/{0}/followers.xml";
            }
        }

        public static string UnfollowUserUrlFormat
        {
            get
            {
                return @"http://www.goodreads.com/user/{0}/followers/stop_following.xml";
            }
        }

        public static string UpdateUserStatusUrl { get; set; }
    }
}
