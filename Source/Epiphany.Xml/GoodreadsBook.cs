using System.Collections.Generic;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("book")]
    public class GoodreadsBook
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("title")]
        public string Title
        {
            get;
            set;
        }

        [XmlArray("authors")]
        [XmlArrayItem("author")]
        public List<GoodreadsAuthor> Authors
        {
            get;
            set;
        }

        // Sometimes, books can have just an author and no author collection
        // This should be used only when Authors.Count = 0
        [XmlElement("author")]
        public GoodreadsAuthor Author
        {
            get;
            set;
        }

        [XmlElement("isbn")]
        public string ISBN
        {
            get;
            set;
        }

        [XmlElement("isbn13")]
        public string ISBN13
        {
            get;
            set;
        }

        [XmlElement("asin")]
        public string ASIN
        {
            get;
            set;
        }

        [XmlElement("image_url")]
        public string ImageUrl
        {
            get;
            set;
        }

        [XmlElement("small_image_url")]
        public string SmallImageUrl
        {
            get;
            set;
        }

        [XmlElement("publication_year")]
        public string PublicationYear
        {
            get;
            set;
        }

        [XmlElement("publication_month")]
        public string PublicationMonth
        {
            get;
            set;
        }

        [XmlElement("publication_day")]
        public string PublicationDay
        {
            get;
            set;
        }

        [XmlElement("publisher")]
        public string Publisher
        {
            get;
            set;
        }

        [XmlElement("language_code")]
        public string LanguageCode
        {
            get;
            set;
        }

        [XmlElement("is_ebook")]
        public string IsEbook
        {
            get;
            set;
        }

        [XmlElement("description")]
        public string Description
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

        [XmlElement("num_pages")]
        public string NumberOfPages
        {
            get;
            set;
        }

        [XmlElement("format")]
        public string Format
        {
            get;
            set;
        }

        [XmlElement("edition_information")]
        public string EditionInfo
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

        [XmlElement("text_reviews_count")]
        public string TextReviewsCount
        {
            get;
            set;
        }

        [XmlElement("url")]
        public string Url
        {
            get;
            set;
        }

        [XmlElement("link")]
        public string Link
        {
            get;
            set;
        }

        [XmlElement("work")]
        public GoodreadsWork Work
        {
            get;
            set;
        }

        [XmlElement("my_review")]
        public GoodreadsReview UserReview
        {
            get;
            set;
        }

        [XmlArray("friend_reviews")]
        [XmlArrayItem("review")]
        public List<GoodreadsReview> FriendReviews
        {
            get;
            set;
        }

        [XmlElement("reviews")]
        public GoodreadsReviews PublicReviews
        {
            get;
            set;
        }

        [XmlArray("popular_shelves")]
        [XmlArrayItem("shelf")]
        public List<GoodreadsShelf> PopularShelves
        {
            get;
            set;
        }

        [XmlArray("book_links")]
        [XmlArrayItem("book_link")]
        public List<GoodreadsBookLink> BookLinks
        {
            get;
            set;
        }

        [XmlArray("similar_books")]
        [XmlArrayItem("book")]
        public List<GoodreadsBook> SimilarBooks
        {
            get;
            set;
        }
    }
}
