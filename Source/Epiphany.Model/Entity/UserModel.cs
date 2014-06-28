using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public sealed class UserModel : Entity<int>
    {
        private readonly int id;
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

        public override int Id
        {
            get 
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.user.Name;
            }
        }

        public string ImageUrl
        {
            get
            {
                return this.user.ImageUrl;
            }
        }

        public string Link
        {
            get
            {
                return this.user.Link;
            }
        }
    }
}
