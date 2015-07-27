using Epiphany.Xml;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Epiphany.Xml
{
    public sealed class Parser
    {
        public static Response GetResponse(string xml)
        {
            Debug.WriteLine("GetResponse = " + Environment.CurrentManagedThreadId);

            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Response));
                return (Response)serializer.Deserialize(reader);
            }
        }
    }
}
