using Epiphany.Model;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class AddShelfCommand : AsyncCommand<string>
    {
        private readonly IBookshelfService service;

        public AddShelfCommand(IBookshelfService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException();
            }

            this.service = service;
        }

        public override bool CanExecute(string shelfName)
        {
            return !string.IsNullOrEmpty(shelfName);
        }

        protected async override Task RunAsync(string shelfName)
        {
            BookshelfModel shelf = new BookshelfModel(0);
            shelf.Name = shelfName;

            await this.service.AddShelf(shelf);
        }
    }
}
