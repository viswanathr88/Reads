using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("GoodreadsResponse")]
    [DataContract(Name = "GoodreadsResponse", Namespace = "")]
    public class AuthUserResponse
    {
        [XmlElement("Request")]
        [DataMember]
        public Request Request
        {
            get;
            set;
        }

        [XmlElement("user")]
        public GoodreadsAuthenticatedUser AuthenticatedUser
        {
            get;
            set;
        }
    }
}
