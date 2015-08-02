using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowSearchCommand : Command
    {
        private readonly INavigationService navService;

        public ShowSearchCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.navService.CreateFor<ISearchViewModel>().Navigate();
        }
    }
}
