using Epiphany.Logging;
using Epiphany.Model.Adapter;
using Epiphany.Xml;
using System;
using System.Collections.Generic;

namespace Epiphany.Model
{
    public sealed class ProfileModel : Entity<long>
    {
        private readonly GoodreadsProfile profile;
        private readonly string name;
        private readonly IAdapter<FeedItemModel, GoodreadsUpdate> feedItemAdapter;
        private IList<FeedItemModel> recentUpdates;
        private IList<AuthorModel> favoriteAuthors;

        internal ProfileModel(GoodreadsProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException("profile", "profile cannot be null");
            }

            this.profile = profile;
            this.name = profile.Name;

            this.feedItemAdapter = new FeedItemAdapter();
            RecentUpdates = new List<FeedItemModel>();
            PopulateRecentUpdates();
            PopulateFavoriteAuthors();
        }

        public override long Id
        {
            get
            {
                return this.profile.Id;
            }
        }

        public string Name
        {
            get { return this.profile.Name; }
        }

        public string ImageUrl
        {
            get
            {
                string url = this.profile.ImageUrl;
                if (string.IsNullOrEmpty(url))
                {
                    url = this.profile.SmallImageUrl;
                }

                return url;
            }
        }

        public string Link
        {
            get { return this.profile.Link; }
        }

        public string Username
        {
            get { return this.profile.Username; }
        }

        public string Gender
        {
            get { return this.profile.Gender; }
        }

        public int Age
        {
            get { return Converter.ToInt(this.profile.Age, 0); }
        }

        public bool IsPrivate
        {
            get { return false; }
        }

        public string AboutInfo
        {
            get { return this.profile.About; }
        }

        public string Location
        {
            get { return this.profile.Location; }
        }

        public string Website
        {
            get { return this.profile.Website; }
        }

        public string FavoriteBooks
        {
            get { return this.profile.FavoriteBooks; }
        }

        public string Interests
        {
            get { return this.profile.Interests; }
        }

        public int FriendsCount
        {
            get { return Converter.ToInt(profile.FriendsCount, 0); }
        }

        public int GroupsCount
        {
            get { return Converter.ToInt(profile.GroupsCount, 0); }
        }

        public int ReviewsCount
        {
            get { return Converter.ToInt(profile.ReviewsCount, 0); }
        }

        public DateTime JoinDate
        {
            get { return Converter.ToDateTime(profile.JoinDate); }
        }

        public bool IsFriend
        {
            get { return Converter.ToBool(profile.IsFriend, false); }
        }

        public bool IsPendingFriendRequest
        {
            get { return this.profile.FriendStatus == "request_pending_to"; }
        }

        public bool IsFollowing
        {
            get
            {
                return Converter.ToBool(this.profile.IsFollowing, false);
            }
        }

        public int ShelvesCount
        {
            get
            {
                return (this.profile.Shelves != null) ? this.profile.Shelves.Count : 0;
            }
        }

        public IList<FeedItemModel> RecentUpdates
        {
            get
            {
                return this.recentUpdates;
            }
            private set
            {
                if (this.recentUpdates != value)
                {
                    this.recentUpdates = value;
                }
            }
        }

        public IList<AuthorModel> FavoriteAuthors
        {
            get
            {
                return this.favoriteAuthors;
            }
            private set
            {
                if (this.favoriteAuthors != value)
                {
                    this.favoriteAuthors = value;
                }
            }
        }

        private void PopulateRecentUpdates()
        {
            RecentUpdates = new List<FeedItemModel>();
            foreach (GoodreadsUpdate update in this.profile.Updates)
            {
                try
                {
                    var model = this.feedItemAdapter.Convert(update);
                    if (model != null)
                    {
                        RecentUpdates.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }

        private void PopulateFavoriteAuthors()
        {
            FavoriteAuthors = new List<AuthorModel>();
            foreach (var author in this.profile.FavoriteAuthors)
            {
                FavoriteAuthors.Add(new AuthorModel(author, null));
            }
        }
    }
}
