
using Epiphany.ViewModel.Services;
namespace Epiphany.ViewModel.Commands
{
    class ShowAboutCommand : Command
    {
        private readonly INavigationService navigationService;

        public ShowAboutCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.navigationService.CreateFor<IAboutViewModel>().Navigate();
        }
    }
}
