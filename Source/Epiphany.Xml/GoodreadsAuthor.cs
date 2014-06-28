using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("author")]
    [DataContract(Name="author", Namespace="")]
    public class GoodreadsAuthor
    {
        [XmlElement("id")]
        [DataMember(Name = "id", Order = 0)]
        public int Id
        {
            get;
            set;
        }

        [XmlElement("name")]
        [DataMember(Name = "name", Order = 1)]
        public string Name
        {
            get;
            set;
        }

        [XmlElement("link")]
        [DataMember(Name = "link", Order = 2)]
        public string Link
        {
            get;
            set;
        }

        [XmlElement("fans_count")]
        [DataMember(Name = "fans_count", Order = 3)]
        public string FansCount
        {
            get;
            set;
        }

        [XmlElement("image_url")]
        [DataMember(Name = "image_url", Order = 4)]
        public string ImageUrl
        {
            get;
            set;
        }

        [XmlElement("small_image_url")]
        [DataMember(Name = "small_image_url", Order = 5)]
        public string SmallImageUrl
        {
            get;
            set;
        }

        [XmlElement("about")]
        [DataMember(Name = "about", Order = 6)]
        public string About
        {
            get;
            set;
        }

        [XmlElement("influences")]
        [DataMember(Name = "influences", Order = 7)]
        public string Influences
        {
            get;
            set;
        }

        [XmlElement("works_count")]
        [DataMember(Name = "works_count", Order = 8)]
        public string WorksCount
        {
            get;
            set;
        }

        [XmlElement("gender")]
        [DataMember(Name = "gender", Order = 9)]
        public string Gender
        {
            get;
            set;
        }

        [XmlElement("hometown")]
        [DataMember(Name = "hometown", Order = 10)]
        public string HomeTown
        {
            get;
            set;
        }

        [XmlElement("born_at")]
        [DataMember(Name = "born_at", Order = 11)]
        public string BornAt
        {
            get;
            set;
        }

        [XmlElement("died_at")]
        [DataMember(Name = "died_at", Order = 12)]
        public string DiedAt
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

        [XmlElement("books")]
        public GoodreadsBooks BookCollection
        {
            get;
            set;
        }
    }
}
