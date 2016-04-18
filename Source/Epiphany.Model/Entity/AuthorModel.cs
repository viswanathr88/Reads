using Epiphany.Model.Collections;
using Epiphany.Xml;
using System;
using System.Threading.Tasks;

namespace Epiphany.Model
{
    public sealed class AuthorModel : Entity<int>
    {
        private readonly GoodreadsAuthor author;
        private readonly IPagedCollection<BookModel> books;


        internal AuthorModel(GoodreadsAuthor author, IPagedCollection<BookModel> books)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author");
            }

            this.author = author;
            this.books = books;
        }

        public override int Id
        {
            get 
            {
                return this.author.Id; 
            }
        }

        public string Name
        {
            get
            {
                return this.author.Name;
            }
        }

        public string Link
        {
            get
            {
                return this.author.Link;
            }
        }

        public int FansCount
        {
            get
            {
                return Converter.ToInt(this.author.FansCount, 0);
            }
        }

        public string ImageUrl
        {
            get
            {
                return this.author.ImageUrl;
            }
        }

        public string About
        {
            get
            {
                return this.author.About;
            }
        }

        public string Influences
        {
            get
            {
                return this.author.Influences;
            }
        }

        public int WorksCount
        {
            get
            {
                return Converter.ToInt(this.author.WorksCount, 0);
            }
        }

        public string Gender
        {
            get
            {
                return this.author.Gender;
            }
        }

        public string Hometown
        {
            get
            {
                return this.author.HomeTown;
            }
        }

        public DateTime BornAt
        {
            get
            {
                return Converter.ToDateTime(this.author.BornAt);
            }
        }

        public DateTime DiedAt
        {
            get
            {
                return Converter.ToDateTime(this.author.DiedAt);
            }
        }

        public double AverageRating
        {
            get
            {
                return Converter.ToDouble(this.author.AverageRating, 0.0);
            }
        }

        public int RatingsCount
        {
            get
            {
                return Converter.ToInt(this.author.RatingsCount, 0);
            }
        }

        public int TextReviewsCount
        {
            get
            {
                return Converter.ToInt(this.author.TextReviewsCount, 0);
            }
        }

        public IPagedCollection<BookModel> Books
        {
            get
            {
                return this.books;
            }
        }

        public Task FlipFanshipAsync()
        {
            throw new NotImplementedException();
        }
    }
}
