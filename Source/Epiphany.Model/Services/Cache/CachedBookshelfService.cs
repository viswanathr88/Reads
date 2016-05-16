using Epiphany.Model.Collections;
using Epiphany.Model.Messaging;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    class CachedBookshelfService : IBookshelfService
    {
        private readonly IBookshelfService baseService;
        private readonly IMessenger messenger;
        private IPagedCollection<BookshelfModel> currentUserShelves;
        private int currentUserId;
        private bool idAvailable;

        public CachedBookshelfService(IBookshelfService service, IMessenger messenger)
        {
            this.baseService = service;
            this.messenger = messenger;
            //
            // Subscribe for messages
            //
            this.messenger.Subscribe<SessionChangedMessage>(this, HandleSessionChanged);
            this.messenger.Subscribe<BookAddedOrRemovedMessage>(this, HandleBookAddedOrRemoved);
        }

        public IPagedCollection<BookshelfModel> GetBookshelves(int userId)
        {
            //
            // If this request is for the self user, check cache
            //
            if (idAvailable && currentUserId == userId)
            {
                if (currentUserShelves == null)
                {
                    this.currentUserShelves = this.baseService.GetBookshelves(userId);
                }

                return this.currentUserShelves;
            }
            else
            {
                return this.baseService.GetBookshelves(userId);
            }
        }

        public async Task AddShelf(BookshelfModel shelf)
        {
            await this.baseService.AddShelf(shelf);
            if (this.currentUserShelves != null)
            {
                this.currentUserShelves.Clear();
            }
        }

        public async Task RemoveShelf(BookshelfModel shelf)
        {
            await this.baseService.AddShelf(shelf);
            this.currentUserShelves.Clear();
        }

        private void HandleSessionChanged(object sender, SessionChangedMessage msg)
        {
            if (msg.Session != null)
            {
                //
                // Store the current user's id
                //
                this.currentUserId = Converter.ToInt(msg.Session.UserId, 0);
                if (this.currentUserId != 0)
                {
                    this.idAvailable = true;
                    return;
                }
            }

            this.idAvailable = false;
            this.currentUserId = 0;
        }

        private void HandleBookAddedOrRemoved(object sender, BookAddedOrRemovedMessage msg)
        {
            if (this.currentUserShelves != null)
            {
                this.currentUserShelves.Clear();
            }
        }
    }
}
