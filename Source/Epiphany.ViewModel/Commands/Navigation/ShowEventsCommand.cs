using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowEventsCommand : Command
    {
        private readonly INavigationService navService;

        public ShowEventsCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.navService.CreateFor<IEventsViewModel>().Navigate();
        }
    }
}
