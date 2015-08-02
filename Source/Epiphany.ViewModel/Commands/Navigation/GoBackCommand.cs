using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    class GoBackCommand : Command
    {
        private readonly INavigationService navigationService;

        public GoBackCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        protected override bool CanExecute()
        {
            return this.navigationService.CanGoBack;
        }

        protected override void Run()
        {
            if (this.navigationService.CanGoBack)
            {
                this.navigationService.GoBack();
            }
        }
    }
}
