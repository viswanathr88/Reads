using Epiphany.Xml;

namespace Epiphany.Model
{
    public class ModeratorModel : Entity<int>
    {
        private readonly GoodreadsGroupUser user;
        private readonly int id;

        internal ModeratorModel(GoodreadsGroupUser user)
        {
            this.user = user;
            this.id = user.User.Id;
        }

        public override int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Title
        {
            get
            {
                return this.user.Title;
            }
        }

        public int CommentsCount
        {
            get
            {
                return Converter.ToInt(user.CommentsCount, 0);
            }
        }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", user.User.FirstName, user.User.LastName).Trim();
            }
        }

        public string ImageUrl
        {
            get
            {
                return user.User.ImageUrl;
            }
        }

        public string Username
        {
            get
            {
                return this.user.User.Username;
            }
        }
    }
}
