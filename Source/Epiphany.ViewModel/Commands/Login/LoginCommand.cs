using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class LoginCommand : AsyncCommand<Uri, VoidType>
    {
        private readonly ILogonService service;

        public LoginCommand(ILogonService service)
        {
            this.service = service;
        }

        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected async override Task RunAsync(VoidType param)
        {
            Result = await this.service.StartLogin();
        }
    }
}
