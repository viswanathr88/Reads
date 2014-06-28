using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    class GoBackCommand : Command<VoidType, VoidType>
    {
        private readonly INavigationService navigationService;

        public GoBackCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override bool CanExecute(VoidType param)
        {
            return this.navigationService.CanGoBack;
        }

        protected override VoidType ExecuteSync(VoidType param)
        {
            if (this.navigationService.CanGoBack)
            {
                this.navigationService.GoBack();
            }
            return VoidType.Empty;
        }
    }
}
