using Epiphany.ViewModel.Services;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    sealed class RateAppCommand : Command
    {
        private readonly IAppRateService service;

        public RateAppCommand(IAppRateService service)
        {
            this.service = service;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.service.RateApp();
        }
    }
}
