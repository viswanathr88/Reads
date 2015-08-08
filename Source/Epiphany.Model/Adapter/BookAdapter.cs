using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiphany.Model.Adapter
{
    class BookAdapter : IAdapter<BookModel, GoodreadsBook>
    {
        public BookModel Convert(GoodreadsBook item)
        {
            return new BookModel(item);
        }
    }
}
