using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("updates")]
    public class GoodreadsUpdates
    {
        [XmlElement("update")]
        public GoodreadsUpdate[] Updates
        {
            get;
            set;
        }
    }
}
