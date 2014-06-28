using System.Collections.Generic;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("search")]
    public class GoodreadsSearch : IPartialCollection<GoodreadsWork>
    {
        [XmlElement("query")]
        public string Query
        {
            get;
            set;
        }

        [XmlElement("results-start")]
        public string Start
        {
            get;
            set;
        }

        [XmlElement("results-end")]
        public string End
        {
            get;
            set;
        }

        [XmlElement("total-results")]
        public string Total
        {
            get;
            set;
        }

        [XmlElement("source")]
        public string Source
        {
            get;
            set;
        }

        [XmlElement("query-time-seconds")]
        public string QueryTimeInSeconds
        {
            get;
            set;
        }

        [XmlElement("results")]
        public GoodreadsWork[] Items
        {
            get;
            set;
        }
    }
}
