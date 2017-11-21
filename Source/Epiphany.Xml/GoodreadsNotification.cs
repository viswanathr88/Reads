using System.Collections.Generic;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("notification")]
    public class GoodreadsNotification
    {
        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlArray("actors")]
        [XmlArrayItem("user")]
        public List<GoodreadsUser> Actors
        {
            get;
            set;
        }

        [XmlElement("new")]
        public string IsNew
        {
            get;
            set;
        }

        [XmlElement("created_at")]
        public string CreatedAt
        {
            get;
            set;
        }

        [XmlElement("body")]
        public GoodreadsNotificationBody Body
        {
            get;
            set;
        }

        [XmlElement("url")]
        public string Url
        {
            get;
            set;
        }

        [XmlElement("resource_type")]
        public string ResourceType
        {
            get;
            set;
        }

        [XmlElement("group_resource_type")]
        public string GroupResourceType
        {
            get;
            set;
        }

        [XmlElement("group_resource")]
        public GoodreadsGroupResource GroupResource
        {
            get;
            set;
        }
    }
}
