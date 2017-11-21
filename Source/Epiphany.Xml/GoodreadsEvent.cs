using System.Xml.Serialization;

namespace Epiphany.Xml
{
    [XmlRoot("event")]
    public class GoodreadsEvent
    {
        [XmlElement("access")]
        public string Access
        {
            get;
            set;
        }

        [XmlElement("address")]
        public string Address
        {
            get;
            set;
        }

        [XmlElement("can_invite_flag")]
        public string CanInvite
        {
            get;
            set;
        }

        [XmlElement("city")]
        public string City
        {
            get;
            set;
        }

        [XmlElement("country_code")]
        public string CountryCode
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

        [XmlElement("end_at")]
        public string EndAt
        {
            get;
            set;
        }

        [XmlElement("event_attending_count")]
        public string AttendingCount
        {
            get;
            set;
        }

        [XmlElement("event_responses_count")]
        public string ResponsesCount
        {
            get;
            set;
        }

        [XmlElement("event_type")]
        public string EventType
        {
            get;
            set;
        }

        [XmlElement("id")]
        public long Id
        {
            get;
            set;
        }

        [XmlElement("postal_code")]
        public string PostalCode
        {
            get;
            set;
        }

        [XmlElement("public_flag")]
        public string IsPublic
        {
            get;
            set;
        }

        [XmlElement("reminder_at")]
        public string ReminderAt
        {
            get;
            set;
        }

        [XmlElement("resource_id")]
        public string ResourceId
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

        [XmlElement("rsvp_end_at")]
        public string RSVPEndAt
        {
            get;
            set;
        }

        [XmlElement("source")]
        public string Source
        {
            get;
            set;
        }

        [XmlElement("start_at")]
        public string StartAt
        {
            get;
            set;
        }

        [XmlElement("state_code")]
        public string StateCode
        {
            get;
            set;
        }

        [XmlElement("title")]
        public string Title
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

        [XmlElement("user_id")]
        public string UserId
        {
            get;
            set;
        }

        [XmlElement("venue")]
        public string Venue
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

        [XmlElement("link")]
        public string Link
        {
            get;
            set;
        }

        [XmlElement("description")]
        public string Description
        {
            get;
            set;
        }
    }
}
