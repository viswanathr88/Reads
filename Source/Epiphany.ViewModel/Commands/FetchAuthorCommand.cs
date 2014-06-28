using Epiphany.Model;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class FetchAuthorCommand : AsyncCommand<AuthorModel, int>
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

        public override bool CanExecute(int param)
        {
            return param > 0;
        }

        protected override async Task<AuthorModel> ExecuteAsync(int param)
        {
            return await this.service.GetAuthorAsync(param);
        }
    }
}
