using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public class ShelfInformation
    {
        private readonly GoodreadsShelf shelf;

        internal ShelfInformation(GoodreadsShelf shelf)
        {
            if (shelf == null)
            {
                throw new ArgumentNullException("shelf");
            }

            this.shelf = shelf;
        }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.shelf.Name2))
                {
                    return this.shelf.Name;
                }
                else
                {
                    return this.shelf.Name2;
                }
            }
        }

        public int Count
        {
            get
            {
                return Converter.ToInt(this.shelf.Count, 0);
            }
        }
    }
}
