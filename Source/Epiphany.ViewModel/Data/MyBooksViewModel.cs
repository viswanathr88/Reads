using Epiphany.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class MyBooksViewModel : DataViewModel<int>
    {
        private readonly IBookshelfService bookshelfService;

        public MyBooksViewModel(IBookshelfService bookshelfService)
        {
            if (bookshelfService == null)
            {
                throw new ArgumentNullException("bookshelfService");
            }

            this.bookshelfService = bookshelfService;
        }

        public override void Load(int id)
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
