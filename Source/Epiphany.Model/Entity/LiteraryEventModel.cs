using Epiphany.Xml;
using System;

namespace Epiphany.Model
{

    public enum LiteraryEventType
    {
        AuthorAppearance,
        BookClubMeeting,
        Other
    };

    public sealed class LiteraryEventModel : Entity<int>
    {
        private readonly int id;
        private readonly GoodreadsEvent literaryEvent;

        public LiteraryEventModel(int id)
        {
            this.id = id;
        }

        internal LiteraryEventModel(GoodreadsEvent literaryEvent)
        {
            this.literaryEvent = literaryEvent;
        }

        public override int Id
        {
            get { return this.id; }
        }

        public string Access
        {
            get { return this.literaryEvent.Access; }
        }

        public string Address
        {
            get { return this.literaryEvent.Address; }
        }

        public bool CanInvite
        {
            get { return Converter.ToBool(this.literaryEvent.CanInvite, false); }
        }

        public string City
        {
            get { return this.literaryEvent.City; }
        }

        public string CountryCode
        {
            get { return this.literaryEvent.CountryCode; }
        }

        public DateTime CreateTime
        {
            get { return Converter.ToDateTime(this.literaryEvent.CreatedAt); }
        }

        public DateTime EndTime
        {
            get { return Converter.ToDateTime(this.literaryEvent.EndAt); }
        }

        public int AttendingCount
        {
            get { return Converter.ToInt(this.literaryEvent.AttendingCount, 0); }
        }

        public int ResponsesCount
        {
            get { return Converter.ToInt(this.literaryEvent.ResponsesCount, 0); }
        }

        public LiteraryEventType EventType
        {
            get { return ToEventType(this.literaryEvent.EventType, LiteraryEventType.Other); }
        }

        public int PostalCode
        {
            get { return Converter.ToInt(this.literaryEvent.PostalCode, 0); }
        }

        public bool IsPublic
        {
            get { return Converter.ToBool(this.literaryEvent.IsPublic, false); }
        }

        public DateTime ReminderTime
        {
            get { return Converter.ToDateTime(this.literaryEvent.ReminderAt); }
        }

        public int ResourceId
        {
            get
            {
                return Converter.ToInt(this.literaryEvent.ResourceId, 0);
            }
        }

        public string ResourceType
        {
            get
            {
                return this.literaryEvent.ResourceId;
            }
        }

        public DateTime RSVPEndTime
        {
            get
            {
                return Converter.ToDateTime(this.literaryEvent.RSVPEndAt);
            }
        }

        public string Source
        {
            get
            {
                return this.literaryEvent.Source;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return Converter.ToDateTime(this.literaryEvent.StartAt);
            }
        }

        public string StateCode
        {
            get
            {
                return this.literaryEvent.StateCode;
            }
        }

        public string Title
        {
            get
            {
                return this.literaryEvent.Title;
            }
        }

        public DateTime LastUpdateTime
        {
            get
            {
                return Converter.ToDateTime(this.literaryEvent.UpdatedAt);
            }
        }

        public int UserId
        {
            get
            {
                return Converter.ToInt(this.literaryEvent.UserId, 0);
            }
        }

        public string Venue
        {
            get
            {
                return this.literaryEvent.Venue;
            }
        }

        public string ImageUrl
        {
            get
            {
                return this.literaryEvent.ImageUrl;
            }
        }

        public string Link
        {
            get
            {
                return this.literaryEvent.Link;
            }
        }

        public string Description
        {
            get
            {
                return this.literaryEvent.Description;
            }
        }

        private LiteraryEventType ToEventType(string value, LiteraryEventType defaultValue)
        {
            LiteraryEventType eventType = LiteraryEventType.AuthorAppearance;
            switch (value)
            {
                case "author_appeareance":
                    eventType = LiteraryEventType.AuthorAppearance;
                    break;
                case "book_club_meeting":
                    eventType = LiteraryEventType.BookClubMeeting;
                    break;
                default:
                    eventType = LiteraryEventType.Other;
                    break;
            }

            return eventType;
        }
    }
}
