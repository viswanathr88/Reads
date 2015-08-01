
using Epiphany.ViewModel.Services;
namespace Epiphany.ViewModel.Commands
{
    class GoHomeCommand : Command<VoidType, VoidType>
    {
        private readonly INavigationService navigationService;

        public GoHomeCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override VoidType ExecuteSync(VoidType param)
        {
            this.navigationService.GoBackAll();
            return VoidType.Empty;
        }
    }
}
