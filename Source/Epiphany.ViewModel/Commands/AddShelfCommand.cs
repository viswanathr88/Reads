using Epiphany.Model;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class AddShelfCommand : AsyncCommand<VoidType, string>
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

        public override bool CanExecute(string param)
        {
            return !string.IsNullOrEmpty(param);
        }

        protected override async Task<VoidType> ExecuteAsync(string shelfName)
        {
            BookshelfModel shelf = new BookshelfModel(0);
            shelf.Name = shelfName;

            await this.service.AddShelf(shelf);
            return new VoidType();
        }
    }
}
