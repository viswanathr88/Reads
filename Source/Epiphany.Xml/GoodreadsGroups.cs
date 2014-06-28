using System.Collections.Generic;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("groups")]
    public class GoodreadsGroups
    {
        [XmlElement("user")]
        public GoodreadsGroupSubUser User
        {
            get;
            set;
        }

        [XmlElement("count")]
        public string Count
        {
            get;
            set;
        }

        [XmlElement("list")]
        public GoodreadsGroupList GroupList
        {
            get;
            set;
        }
    }
}
