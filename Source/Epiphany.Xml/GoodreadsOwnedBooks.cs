using System;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("owned_books")]
    public class GoodreadsOwnedBooks : IPartialCollection<GoodreadsOwnedBook>
    {
        [XmlAttribute("end")]
        public string End
        {
            get;
            set;
        }

        [XmlElement("owned_book")]
        public GoodreadsOwnedBook[] Items
        {
            get;
            set;
        }

        [XmlAttribute("start")]
        public string Start
        {
            get;
            set;
        }

        [XmlAttribute("total")]
        public string Total
        {
            get;
            set;
        }
    }
}
