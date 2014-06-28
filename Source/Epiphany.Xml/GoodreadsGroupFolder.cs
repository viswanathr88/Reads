using System.Collections.Generic;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("folder")]
    public class GoodreadsGroupFolder
    {
        [XmlElement("id")]
        public string Id
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

        [XmlElement("items_count")]
        public string ItemsCount
        {
            get;
            set;
        }

        [XmlElement("sub_items_count")]
        public string SubItemsCount
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

        [XmlElement("topics")]
        public GoodreadsTopics Topics
        {
            get;
            set;
        }
    }
}
