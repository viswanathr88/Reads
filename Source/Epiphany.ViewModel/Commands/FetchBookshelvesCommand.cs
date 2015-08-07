using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.Model.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class FetchBookshelvesCommand : AsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>>
    {
        private readonly IBookshelfService bookshelfService;
        private const int count = 10;

        public FetchBookshelvesCommand(IBookshelfService bookshelfService)
        {
            if (bookshelfService == null)
            {
                throw new ArgumentNullException("bookshelfService");
            }

            this.bookshelfService = bookshelfService;
        }

        public override bool CanExecute(IAsyncEnumerator<BookshelfModel> param)
        {
            return true;
        }

        protected async override Task RunAsync(IAsyncEnumerator<BookshelfModel> param)
        {
            IList<BookshelfModel> shelves = new List<BookshelfModel>();
            for (int i = 0; i < count; i++)
            {
                await param.MoveNext();
                shelves.Add(param.Current);
            }

            Result = shelves;
        }
    }
}
