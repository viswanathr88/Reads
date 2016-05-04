using Epiphany.Model.Collections;
using Epiphany.Xml;
using System;
using System.Collections.Generic;

namespace Epiphany.Model
{
    public sealed class BookModel : Entity<int>
    {
        private GoodreadsBook book;
        private readonly GoodreadsReview review;

        internal BookModel(GoodreadsBook book)
        {
            if (book == null)
                throw new ArgumentNullException("book", "book cannot be null");

            this.book = book;
        }

        internal BookModel(GoodreadsReview review)
        {
            if (review == null || review.Book == null)
                throw new ArgumentNullException();

            this.review = review;
            this.book = review.Book;
        }

        internal GoodreadsBook Inner
        {
            get { return this.book; }
            set { this.book = value; }
        }

        public override int Id
        {
            get 
            {
                return this.book.Id;
            }
        }

        public string Title
        {
            get
            {
                return this.book.Title;
            }
        }

        public string ISBN
        {
            get
            {
                return this.book.ISBN;
            }
        }

        public string ISBN13
        {
            get
            {
                return this.book.ISBN13;
            }
        }

        public string ImageUrl
        {
            get
            {
                return string.IsNullOrEmpty(book.ImageUrl) ? book.SmallImageUrl : book.ImageUrl;
            }
        }

        public DateTime PublicationDate
        {
            get
            {
                DateTime dt = default(DateTime);
                int year = Converter.ToInt(this.book.PublicationYear, 0);
                if (year != 0)
                {
                    int month = Converter.ToInt(this.book.PublicationMonth, 1);
                    int day = Converter.ToInt(this.book.PublicationDay, 1);
                    dt = new DateTime(year, month, day);
                }
                return dt;
            }
        }

        public string Publisher
        {
            get
            {
                return this.book.Publisher;
            }
        }

        public bool IsEbook
        {
            get
            {
                return Converter.ToBool(this.book.IsEbook, false);
            }
        }

        public string Description
        {
            get
            {
                return this.book.Description;
            }
        }

        public double AverageRating
        {
            get
            {
                return Converter.ToDouble(this.book.AverageRating, 0.0);
            }
        }

        public int NumberOfPages
        {
            get
            {
                return Converter.ToInt(this.book.NumberOfPages, 0);
            }
        }

        public string EditionInformation
        {
            get
            {
                return this.book.EditionInfo;
            }
        }

        public string Url
        {
            get
            {
                return this.book.Url;
            }
        }

        public string Link
        {
            get
            {
                return this.book.Link;
            }
        }

        public int RatingsCount
        {
            get
            {
                return Converter.ToInt(this.book.RatingsCount, 0);
            }
        }

        public int TextReviewsCount
        {
            get
            {
                return Converter.ToInt(this.book.TextReviewsCount, 0);
            }
        }

        public string Format
        {
            get
            {
                return this.book.Format;
            }
        }

        public ReviewModel UserReview
        {
            get
            {
                ReviewModel model = null;
                if (this.book.UserReview != null)
                {
                    model = new ReviewModel(this.book.UserReview);
                }
                else if (this.review != null)
                {
                    model = new ReviewModel(this.review);
                }
                return model;
            }
        }

        public IList<ReviewModel> FriendReviews
        {
            get
            {
                IList<ReviewModel> reviews = new List<ReviewModel>();
                if (this.book.FriendReviews != null)
                {
                    foreach (GoodreadsReview review in this.book.FriendReviews)
                    {
                        reviews.Add(new ReviewModel(review));
                    }
                }
                return reviews;
            }
        }

        public IList<AuthorModel> Authors
        {
            get
            {
                IList<AuthorModel> authors = new List<AuthorModel>();
                if (this.book.Authors != null && this.book.Authors.Count > 0)
                {
                    foreach (GoodreadsAuthor author in this.book.Authors)
                    {
                        authors.Add(new AuthorModel(author, null));
                    }
                }
                else if (this.book.Author != null)
                {
                    authors.Add(new AuthorModel(this.book.Author, null));
                }

                return authors;
            }
        }

        public IList<BookLinkModel> BookLinks
        {
            get
            {
                IList<BookLinkModel> links = new List<BookLinkModel>();
                if (this.book.BookLinks != null)
                {
                    foreach (GoodreadsBookLink link in this.book.BookLinks)
                    {
                        links.Add(new BookLinkModel(link));
                    }
                }
                return links;
            }
        }

        public IList<ShelfInformation> PopularShelves
        {
            get
            {
                IList<ShelfInformation> shelves = new List<ShelfInformation>();
                if (this.book.PopularShelves != null)
                {
                    foreach (GoodreadsShelf shelf in this.book.PopularShelves)
                    {
                        shelves.Add(new ShelfInformation(shelf));
                    }
                }
                return shelves;
            }
        }

        public IList<BookModel> SimilarBooks
        {
            get
            {
                IList<BookModel> books = new List<BookModel>();
                if (this.book.SimilarBooks != null)
                {
                    foreach (GoodreadsBook book in this.book.SimilarBooks)
                    {
                        books.Add(new BookModel(book));
                    }
                }
                return books;
            }
        }
    }
}
