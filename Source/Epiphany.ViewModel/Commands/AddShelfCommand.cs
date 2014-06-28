using Epiphany.Model;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class AddShelfCommand : AsyncCommand<VoidType, BookshelfModel>
    {
        private readonly IBookshelfService service;

        public AddShelfCommand(IBookshelfService service)
        {
            if (this.service == null)
            {
                throw new ArgumentNullException();
            }

            this.service = service;
        }

        public override bool CanExecute(BookshelfModel param)
        {
            return (param.Id == 0 && !string.IsNullOrEmpty(param.Name));
        }

        protected override async Task<VoidType> ExecuteAsync(BookshelfModel param)
        {
            await this.service.AddShelf(param);
            return new VoidType();
        }
    }
}
