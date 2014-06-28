using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("book_link")]
    public class GoodreadsBookLink
    {
        [XmlElement("id")]
        public int Id
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

        [XmlElement("link")]
        public string Link
        {
            get;
            set;
        }
    }
}
