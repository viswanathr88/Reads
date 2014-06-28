using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [DataContract(Name="Request", Namespace="")]
    public class Request
    {
        [XmlElement("authentication")]
        [DataMember(Name="authentication")]
        public bool IsAuthenticated
        {
            get;
            set;
        }

        [XmlElement("key")]
        [DataMember(Name="key")]
        public string Key
        {
            get;
            set;
        }

        [XmlElement("method")]
        [DataMember(Name="method")]
        public string Method
        {
            get;
            set;
        }
    }
}
