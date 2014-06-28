using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public class UserStatusModel : Entity<int>
    {
        private readonly GoodreadsUserStatus status;
        private readonly int id;

        public static UserStatusModel Create(BookModel book, int page, int percentage, string body)
        {
            return new UserStatusModel(page, percentage, body, book.Id);
        }


        internal UserStatusModel(GoodreadsUserStatus status)
        {
            this.status = status;
            this.id = status.Id;
        }

        private UserStatusModel(int page, int percentage, string body, int bookId)
        {
            this.status = new GoodreadsUserStatus()
            {
                Body = body,
                Page = page.ToString(),
                Percent = percentage.ToString(),
                Book = new GoodreadsBook()
                {
                    Id = bookId
                }
            };
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
                return this.status.Body;
            }
        }

        public int Page
        {
            get
            {
                return Converter.ToInt(status.Page, 0);
            }
        }

        public int Percentage
        {
            get
            {
                return Converter.ToInt(status.Percent, 0);
            }
        }

        public string Chapter
        {
            get
            {
                return status.Chapter;
            }
        }

        public int CommentsCount
        {
            get
            {
                return Converter.ToInt(status.CommentsCount, 0);
            }
        }

        public DateTime LastCommentTime
        {
            get
            {
                return Converter.ToDateTime(status.LastCommentAt);
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                return Converter.ToDateTime(status.UpdatedAt);
            }
        }

        public int ReviewId
        {
            get
            {
                return Converter.ToInt(status.ReviewId, 0);
            }
        }

        public BookModel Book
        {
            get
            {
                return new BookModel(status.Book);
            }
        }
    }
}
