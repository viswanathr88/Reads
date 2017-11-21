using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public sealed class UserModel : Entity<long>
    {
        private readonly long id;
        private readonly GoodreadsUser user;

        public UserModel(int id)
        {
            this.id = id;
            this.user = new GoodreadsUser();
        }

        internal UserModel(GoodreadsUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "user cannot be null");

            this.user = user;
            this.id = user.Id;
        }

        public override long Id
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return this.user.Name; }
            set
            {
                if (this.user.Name == value) return;
                this.user.Name = value;
            }
        }

        public string ImageUrl
        {
            get { return this.user.ImageUrl; }
            set
            {
                if (this.user.ImageUrl == value) return;
                this.user.ImageUrl = value;
            }
        }

        public string Link
        {
            get { return this.user.Link; }
            set
            {
                if (this.user.Link == value) return;
                this.user.Link = value;
            }
        }
    }
}
