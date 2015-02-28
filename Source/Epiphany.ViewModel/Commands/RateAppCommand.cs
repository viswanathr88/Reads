using Epiphany.ViewModel.Services;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    class RateAppCommand : Command<VoidType, VoidType>
    {
        private readonly IAppRateService service;

        public RateAppCommand(IAppRateService service)
        {
            this.service = service;
        }

        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override VoidType ExecuteSync(VoidType param)
        {
            this.service.RateApp();
            return VoidType.Empty;
        }
    }
}
