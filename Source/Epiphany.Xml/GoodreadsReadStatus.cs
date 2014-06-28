using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("read_status")]
    public class GoodreadsReadStatus
    {
        [XmlElement("id")]
        public int Id
        {
            get;
            set;
        }

        [XmlElement("review_id")]
        public string ReviewId
        {
            get;
            set;
        }

        [XmlElement("status")]
        public string Status
        {
            get;
            set;
        }

        [XmlElement("updated_at")]
        public string UpdatedAt
        {
            get;
            set;
        }

        [XmlElement("user_id")]
        public string UserId
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
