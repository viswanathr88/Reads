using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("user")]
    public class GoodreadsUser
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

        [XmlElement("location")]
        public string Location
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
    }
}
