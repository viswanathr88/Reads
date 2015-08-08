using Epiphany.Model;
using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowBookCommand : Command<BookModel>
    {
        private readonly INavigationService navService;

        public ShowBookCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        public override bool CanExecute(BookModel book)
        {
            return book.Id >= 0;
        }

        protected override void Run(BookModel book)
        {
            this.navService.CreateFor<IBookViewModel>()
                .AddParam<int>((x) => x.Id, book.Id)
                .AddParam<string>((x) => x.Name, book.Title)
                .Navigate();
        }
    }
}
