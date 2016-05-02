using Epiphany.Model;
using Epiphany.Model.Services;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class AddToReadingListCommand : AsyncCommand<BookModel>
    {
        private readonly IBookService bookService;

        public AddToReadingListCommand(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public override bool CanExecute(BookModel book)
        {
            bool fCanExecute = (book.UserReview == null);
            return fCanExecute;
        }

        protected override async Task RunAsync(BookModel book)
        {
            BookshelfModel shelf = BookshelfModel.Create("to-read", false, true);
            await this.bookService.AddBook(shelf, book);
        }
    }
}
