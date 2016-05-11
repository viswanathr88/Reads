﻿
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
                return "book/show";
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
                return baseUrl + "review/list";
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
                return baseUrl + "shelf/list";
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
                return "https://www.goodreads.com/shelf/add_to_shelf";
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
                return baseUrl + "updates/friends.xml";
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
                return @"http://www.goodreads.com/search";
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
