using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    class ShowOptionsCommand : Command<VoidType, VoidType>
    {
        private readonly INavigationService navigationService;

        public ShowOptionsCommand(INavigationService service)
        {
            this.navigationService = service;
        }
        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override VoidType ExecuteSync(VoidType param)
        {
            this.navigationService.CreateFor<FeedOptionsViewModel>().Navigate();
            return VoidType.Empty;
        }
    }
}
