using Epiphany.Model.Services;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class FinishLoginCommand : AsyncCommand<VoidType, VoidType>
    {
        private readonly ILogonService logonService;

        public FinishLoginCommand(ILogonService logonService)
        {
            this.logonService = logonService;
        }

        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override async Task<VoidType> ExecuteAsync(VoidType param)
        {
            await this.logonService.FinishLogin();
            return VoidType.Empty;
        }
    }
}
