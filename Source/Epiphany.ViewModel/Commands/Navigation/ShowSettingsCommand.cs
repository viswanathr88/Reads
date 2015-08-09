using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowSettingsCommand : Command
    {
        private readonly INavigationService navService;

        public ShowSettingsCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.navService.CreateFor<ISettingsViewModel>().Navigate();
        }
    }
}
