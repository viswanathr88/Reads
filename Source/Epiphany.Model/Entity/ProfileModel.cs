using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public sealed class ProfileModel : Entity<int>
    {
        private readonly GoodreadsProfile profile;
        private readonly int id;
        private readonly string name;

        public ProfileModel(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.profile = new GoodreadsProfile();
        }

        internal ProfileModel(GoodreadsProfile profile)
        {
            if (profile == null)
                throw new ArgumentNullException("profile", "profile cannot be null");

            this.profile = profile;
            this.id = profile.Id;
            this.name = profile.Name;
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

        public DateTime JoinDate
        {
            get { return Converter.ToDateTime(profile.JoinDate); }
        }

        public bool IsFriend
        {
            get { return false; }
        }
    }
}
