using Epiphany.Logging;
using Epiphany.Model.Adapter;
using Epiphany.Xml;
using System;
using System.Collections.Generic;

namespace Epiphany.Model
{
    public sealed class ProfileModel : Entity<int>
    {
        private readonly GoodreadsProfile profile;
        private readonly int id;
        private readonly string name;
        private readonly IAdapter<FeedItemModel, GoodreadsUpdate> feedItemAdapter;

        public ProfileModel(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.profile = new GoodreadsProfile();

            this.feedItemAdapter = new FeedItemAdapter();
        }

        internal ProfileModel(GoodreadsProfile profile)
        {
            if (profile == null)
                throw new ArgumentNullException("profile", "profile cannot be null");

            this.profile = profile;
            this.id = profile.Id;
            this.name = profile.Name;

            this.feedItemAdapter = new FeedItemAdapter();
        }

        public override int Id
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

        public IList<FeedItemModel> RecentUpdates
        {
            get
            {
                IList<FeedItemModel> updates = new List<FeedItemModel>();
                foreach (GoodreadsUpdate update in this.profile.Updates)
                {
                    try
                    {
                        var model = this.feedItemAdapter.Convert(update);
                        if (model != null)
                        {
                            updates.Add(model);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex);
                    }
                }
                return updates;
            }
        }

        public IList<AuthorModel> FavoriteAuthors
        {
            get
            {
                IList<AuthorModel> authors = new List<AuthorModel>();
                foreach (var author in this.profile.FavoriteAuthors)
                {
                    authors.Add(new AuthorModel(author, null));
                }

                return authors;
            }
        }
    }
}
