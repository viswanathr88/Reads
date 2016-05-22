using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("work")]
    public class GoodreadsWork
    {
        [XmlElement("id")]
        public int Id
        {
            get;
            set;
        }

        [XmlElement("books_count")]
        public string BooksCount
        {
            get;
            set;
        }

        [XmlElement("media_type")]
        public string MediaType
        {
            get;
            set;
        }

        [XmlElement("original_title")]
        public string OriginalTitle
        {
            get;
            set;
        }

        [XmlElement("ratings_count")]
        public string RatingsCount
        {
            get;
            set;
        }

        [XmlElement("ratings_sum")]
        public string RatingsSum
        {
            get;
            set;
        }

        [XmlElement("rating_dist")]
        public string RatingsDistribution
        {
            get;
            set;
        }

        [XmlElement("reviews_count")]
        public string ReviewsCount
        {
            get;
            set;
        }

        [XmlElement("text_reviews_count")]
        public string TextReviewsCount
        {
            get;
            set;
        }

        [XmlElement("average_rating")]
        public string AverageRating
        {
            get;
            set;
        }

        [XmlElement("original_publication_day")]
        public string OriginalPublicationDay
        {
            get;
            set;
        }

        [XmlElement("original_publication_month")]
        public string OriginalPublicationMonth
        {
            get;
            set;
        }

        [XmlElement("original_publication_year")]
        public string OriginalPublicationYear
        {
            get;
            set;
        }

        [XmlElement("best_book")]
        public GoodreadsBook BestBook
        {
            get;
            set;
        }
    }
}
