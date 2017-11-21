using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("user_shelf")]
    public class GoodreadsUserShelf
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("name")]
        public string Name
        {
            get;
            set;
        }

        [XmlElement("book_count")]
        public string BookCount
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

        [XmlElement("display_fields")]
        public string DisplayFields
        {
            get;
            set;
        }

        [XmlElement("exlusive_flag")]
        public string IsExclusive
        {
            get;
            set;
        }

        [XmlElement("featured")]
        public string IsFeatured
        {
            get;
            set;
        }

        [XmlElement("sticky")]
        public string IsSticky
        {
            get;
            set;
        }
    }
}
