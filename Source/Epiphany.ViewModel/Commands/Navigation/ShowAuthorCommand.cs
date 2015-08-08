using Epiphany.Model;
using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowAuthorCommand : Command<AuthorModel>
    {
        private readonly INavigationService navService;

        public ShowAuthorCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        public override bool CanExecute(AuthorModel author)
        {
            return author.Id >= 0;
        }

        protected override void Run(AuthorModel author)
        {
            this.navService.CreateFor<IAuthorViewModel>()
                .AddParam<int>((x) => x.Id, author.Id)
                .AddParam<string>((x) => x.Name, author.Name)
                .Navigate();
        }
    }
}
