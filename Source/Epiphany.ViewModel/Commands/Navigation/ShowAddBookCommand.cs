
using Epiphany.Model;
using Epiphany.ViewModel.Services;
namespace Epiphany.ViewModel.Commands
{
    class ShowAddBookCommand : Command<VoidType, BookModel>
    {
        private readonly INavigationService navigationService;

        public ShowAddBookCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        /*public override void Execute(Book book)
        {
            this.viewServices.DisplayAddBook(book.Id, book.Title);
        }*/

        public override bool CanExecute(BookModel param)
        {
            return param.UserReview == null;
        }

        protected override VoidType ExecuteSync(BookModel param)
        {
            return VoidType.Empty;
        }
    }
}
