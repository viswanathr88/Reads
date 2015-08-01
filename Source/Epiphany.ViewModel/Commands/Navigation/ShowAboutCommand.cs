
using Epiphany.ViewModel.Services;
namespace Epiphany.ViewModel.Commands
{
    class ShowAboutCommand : Command<VoidType, VoidType>
    {
        private readonly INavigationService navigationService;

        public ShowAboutCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override VoidType ExecuteSync(VoidType param)
        {
            this.navigationService.CreateFor<IAboutViewModel>().Navigate();
            return VoidType.Empty;
        }
    }
}
