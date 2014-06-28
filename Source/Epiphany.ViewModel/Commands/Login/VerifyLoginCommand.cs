using Epiphany.Model.Services;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class VerifyLoginCommand : AsyncCommand<bool, VoidType>
    {
        private readonly ILogonService service;

        public VerifyLoginCommand(ILogonService service)
        {
            this.service = service;
        }

        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override async Task<bool> ExecuteAsync(VoidType param)
        {
            return await this.service.TryVerifyLogin();
        }
    }
}
