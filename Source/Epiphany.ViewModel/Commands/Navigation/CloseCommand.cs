using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    class CloseCommand : Command<VoidType, VoidType>
    {
        private readonly INavigationService navigationService;

        public CloseCommand(INavigationService navigationService)
        {
            if (navigationService == null)
            {
                throw new ArgumentNullException("navigationService");
            }

            this.navigationService = navigationService;
        }

        public override bool CanExecute(VoidType param)
        {
            return true;
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
