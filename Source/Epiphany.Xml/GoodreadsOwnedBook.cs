using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("owned_book")]
    public class GoodreadsOwnedBook
    {
        [XmlElement("book")]
        public GoodreadsBook Book
        {
            get;
            set;
        }

        [XmlElement("review")]
        public GoodreadsReview Review
        {
            get;
            set;
        }
    }
}
