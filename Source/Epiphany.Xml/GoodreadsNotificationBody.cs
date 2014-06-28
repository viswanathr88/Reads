using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("body")]
    public class GoodreadsNotificationBody
    {
        [XmlElement("html")]
        public string Html
        {
            get;
            set;
        }

        [XmlElement("text")]
        public string Text
        {
            get;
            set;
        }
    }
}
