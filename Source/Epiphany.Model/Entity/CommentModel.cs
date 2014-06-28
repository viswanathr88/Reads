using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public class CommentModel : Entity<int>
    {
        private readonly int id;
        private readonly GoodreadsComment comment;

        public static CommentModel Create(string body)
        {
            return new CommentModel(body);          
        }

        private CommentModel(string body)
        {
            this.comment = new GoodreadsComment()
            {
                Body = body
            };
        }

        internal CommentModel(GoodreadsComment comment)
        {
            this.comment = comment;
            this.id = comment.Id;
        }

        public override int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Body
        {
            get
            {
                return this.comment.Body;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                return Converter.ToDateTime(this.comment.UpdatedAt);
            }
        }

        public UserModel User
        {
            get
            {
                return new UserModel(comment.User);
            }
        }
    }
}
