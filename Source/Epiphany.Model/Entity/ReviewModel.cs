using Epiphany.Xml;
using System;
using System.Collections.Generic;

namespace Epiphany.Model
{
    public sealed class ReviewModel : Entity<int>
    {
        private readonly GoodreadsReview review;
        private readonly int id;

        internal ReviewModel(GoodreadsReview review)
        {
            this.review = review;
            this.id = review.Id;
        }
        
        public override int Id
        {
            get 
            {
                return review.Id;
            }
        }

        public UserModel User
        {
            get
            {
                return new UserModel(review.User);
            }
        }

        public int Rating
        {
            get
            {
                return Converter.ToInt(review.Rating, 0);
            }
        }

        public int Votes
        {
            get
            {
                return Converter.ToInt(review.Votes, 0);
            }
        }

        public bool IsSpoiler
        {
            get
            {
                return Converter.ToBool(review.IsSpoiler, false);
            }
        }

        public string RecommendedFor
        {
            get
            {
                return this.review.RecommendedFor;
            }
        }

        public string RecommendedBy
        {
            get
            {
                return this.review.RecommendedBy;
            }
        }

        public DateTime ReadDate
        {
            get
            {
                return Converter.ToDateTime(this.review.ReadAt);
            }
        }

        public DateTime AddedDate
        {
            get
            {
                return Converter.ToDateTime(this.review.DateAdded);
            }
        }

        public DateTime LastUpdatedDate
        {
            get
            {
                return Converter.ToDateTime(this.review.DateUpdated);
            }
        }

        public int ReadCount
        {
            get
            {
                return Converter.ToInt(this.review.ReadCount, 0);
            }
        }

        public string Body
        {
            get
            {
                return Converter.ToPlainText(this.review.Body);
            }
        }

        public int CommentsCount
        {
            get
            {
                return Converter.ToInt(this.review.CommentsCount, 0);
            }
        }

        public string Url
        {
            get
            {
                return this.review.Url;
            }
        }

        public string Link
        {
            get
            {
                return this.review.Link;
            }
        }

        public IEnumerable<string> Shelves
        {
            get
            {
                IList<string> shelves = new List<string>();
                foreach (GoodreadsShelf shelf in this.review.Shelves)
                {
                    string name = string.IsNullOrEmpty(shelf.Name) ? shelf.Name2 : shelf.Name;
                    shelves.Add(name);
                }

                return shelves;
            }
        }
    }
}
