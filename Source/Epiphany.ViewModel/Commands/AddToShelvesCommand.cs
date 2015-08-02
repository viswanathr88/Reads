using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class AddToShelvesCommand : AsyncCommand<AddToShelvesCommandArgs>
    {
        private readonly IBookService bookService;

        public AddToShelvesCommand(IBookService bookService)
        {
            if (bookService == null)
            {
                throw new ArgumentNullException("bookService");
            }

            this.bookService = bookService;
        }

        public override bool CanExecute(AddToShelvesCommandArgs args)
        {
            return args.Book != null && args.ChangesList.Count > 0;
        }

        protected async override Task RunAsync(AddToShelvesCommandArgs args)
        {
            foreach (DeltaListItem<string> item in args.ChangesList)
            {
                if (IsStandardShelf(item.Item))
                {
                    if (item.Operation == DeltaListOperation.Added)
                    {
                        BookshelfModel shelf = new BookshelfModel(0);
                        shelf.Name = item.Item;

                        await this.bookService.AddBook(shelf, args.Book);
                    }
                    else
                    {
                        // just ignore the removes as the server will do it automatically
                        // when books move between standard shelves
                    }
                }
                else
                {
                    if (item.Operation == DeltaListOperation.Added)
                    {
                        BookshelfModel shelf = new BookshelfModel(0);
                        shelf.Name = item.Item;

                        await this.bookService.AddBook(shelf, args.Book);
                    }
                    else
                    {
                        BookshelfModel shelf = new BookshelfModel(0);
                        shelf.Name = item.Item;

                        await this.bookService.RemoveBook(shelf, args.Book);
                    }
                }
            }
        }
        private bool IsStandardShelf(string shelf)
        {
            return shelf == "currently-reading" || shelf == "read" || shelf == "to-read";
        }
    }
}
