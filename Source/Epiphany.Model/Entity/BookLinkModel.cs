using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public class BookLinkModel : Entity<int>
    {
        private readonly GoodreadsBookLink bookLink;

        internal BookLinkModel(GoodreadsBookLink bookLink)
        {
            if (bookLink == null)
            {
                throw new ArgumentNullException("bookLink");
            }
            this.bookLink = bookLink;
        }

        public override int Id
        {
            get
            {
                return this.bookLink.Id;
            }
        }

        public string Name
        {
            get
            {
                return this.bookLink.Name;
            }
        }

        public string Link
        {
            get
            {
                return this.bookLink.Link;
            }
        }
    }
}
