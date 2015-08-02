
using Epiphany.ViewModel.Services;
namespace Epiphany.ViewModel.Commands
{
    class GoHomeCommand : Command
    {
        private readonly INavigationService navigationService;

        public GoHomeCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.navigationService.GoBackAll();
        }
    }
}
