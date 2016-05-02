using Epiphany.Model;
using Epiphany.Model.Services;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class RemoveFromReadingListCommand : AsyncCommand<BookModel>
    {
        private readonly IBookService bookService;

        public RemoveFromReadingListCommand(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public override bool CanExecute(BookModel book)
        {
            return (book.UserReview != null);
        }

        protected override async Task RunAsync(BookModel book)
        {
            BookshelfModel shelf = BookshelfModel.Create("to-read", false, true);
            await this.bookService.RemoveBook(shelf, book);
        }
    }
}
