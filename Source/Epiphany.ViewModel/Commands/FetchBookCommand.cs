using Epiphany.Model;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class FetchBookCommand : AsyncCommand<BookModel, int>
    {
        private readonly IBookService service;

        public FetchBookCommand(IBookService service)
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

        protected async override Task RunAsync(int param)
        {
            Result = await this.service.GetBook(param);
        }
    }
}
