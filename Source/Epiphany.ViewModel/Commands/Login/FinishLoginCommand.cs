using Epiphany.Model.Services;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class FinishLoginCommand : AsyncCommand
    {
        private readonly ILogonService logonService;

        public FinishLoginCommand(ILogonService logonService)
        {
            this.logonService = logonService;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected async override Task RunAsync()
        {
            await this.logonService.FinishLogin();
        }
    }
}
