using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public sealed class ReviewModel : Entity<int>
    {
        private readonly GoodreadsReview review;
        private readonly int id;
        private readonly int rating;
        private readonly string body;

        public ReviewModel(GoodreadsReview review)
        {
            this.review = review;
            this.id = review.Id;
            this.rating = Converter.ToInt(review.Rating, 0);
            this.body = review.Body;
        }

        public static ReviewModel Create(int rating, string body)
        {
            return new ReviewModel(rating, body);
        }

        private ReviewModel(int rating, string body)
        {
            this.rating = rating;
            this.body = body;
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
                return this.review.Body;
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
    }
}
