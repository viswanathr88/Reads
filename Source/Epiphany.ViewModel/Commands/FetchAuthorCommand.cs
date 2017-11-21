using Epiphany.Model;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class FetchAuthorCommand : AsyncCommand<AuthorModel, long>
    {
        private readonly IAuthorService service;

        public FetchAuthorCommand(IAuthorService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }
            this.service = service;
        }

        public override bool CanExecute(long param)
        {
            return param > 0;
        }

        protected async override Task RunAsync(long param)
        {
            Result = await this.service.GetAuthorAsync(param);
        }
    }
}
