using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("notifications")]
    public class GoodreadsNotifications
    {
        [XmlElement("notification")]
        public GoodreadsNotification[] Notifications
        {
            get;
            set;
        }
    }
}
