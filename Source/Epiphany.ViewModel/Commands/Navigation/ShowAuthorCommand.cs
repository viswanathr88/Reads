using Epiphany.Model;
using Epiphany.ViewModel.Items;
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
            this.navService.CreateFor<AuthorViewModel>()
                .AddParam<int>((x) => x.Id, author.Id)
                .AddParam<string>((x) => x.Name, author.Name)
                .Navigate();
        }
    }

    sealed class ShowAuthorFromItemCommand : Command<AuthorItemViewModel>
    {
        private readonly INavigationService navService;

        public ShowAuthorFromItemCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        public override bool CanExecute(AuthorItemViewModel author)
        {
            return author.Id >= 0;
        }

        protected override void Run(AuthorItemViewModel author)
        {
            this.navService.CreateFor<AuthorViewModel>()
                .AddParam<int>((x) => x.Id, author.Id)
                .AddParam<string>((x) => x.Name, author.Name)
                .Navigate();
        }
    }
}
