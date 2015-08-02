using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    class CloseCommand : Command
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

        protected override bool CanExecute()
        {
            return true;
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
