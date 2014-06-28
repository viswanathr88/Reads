using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("update")]
    public class GoodreadsUpdate
    {
        [XmlAttribute("type")]
        public string Type
        {
            get;
            set;
        }

        [XmlElement("action_text")]
        public string ActionText
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

        [XmlElement("actor")]
        public GoodreadsUser Actor
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

        [XmlElement("updated_at")]
        public string UpdatedAt
        {
            get;
            set;
        }

        [XmlElement("body")]
        public string Body
        {
            get;
            set;
        }

        [XmlElement("action")]
        public GoodreadsUpdateAction Action
        {
            get;
            set;
        }

        [XmlElement("object")]
        public GoodreadsUpdateObject Object
        {
            get;
            set;
        }
    }
}
