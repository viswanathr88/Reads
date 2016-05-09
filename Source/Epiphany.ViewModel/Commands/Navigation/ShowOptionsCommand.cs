using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    class ShowOptionsCommand : Command
    {
        private readonly INavigationService navigationService;

        public ShowOptionsCommand(INavigationService service)
        {
            this.navigationService = service;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            //this.navigationService.CreateFor<FeedOptionsViewModel>().Navigate();
        }
    }
}
