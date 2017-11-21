using Epiphany.Model.Collections;
using Epiphany.Model.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    class CachedBookService : IBookService
    {
        private readonly IBookService baseService;
        private readonly IMessenger messenger;
        private readonly IDictionary<long, BookModel> cache;

        public CachedBookService(IBookService service, IMessenger messenger)
        {
            this.baseService = service;
            this.messenger = messenger;
            this.cache = new Dictionary<long, BookModel>();
            //
            // Subscribe for messages
            //
            this.messenger.Subscribe<ReviewAddedOrEditedMessage>(this, HandleReviewAddedOrEdited);
        }

        public async Task<BookModel> GetBook(long id)
        {
            if (cache.ContainsKey(id))
            {
                return cache[id];
            }
            else
            {
                BookModel model = await this.baseService.GetBook(id);
                cache[id] = model;
                return model;
            }
        }

        public IPagedCollection<BookModel> GetBooks(AuthorModel author)
        {
            return this.baseService.GetBooks(author);
        }

        public IPagedCollection<BookModel> GetBooks(long userId, string shelfName, BookSortType sortType, BookSortOrder order)
        {
            return this.baseService.GetBooks(userId, shelfName, sortType, order);
        }

        public async Task AddBook(BookshelfModel shelf, BookModel book)
        {
            await this.baseService.AddBook(shelf, book);
            //
            // Invalidate the cache and send a message
            //
            if (cache.ContainsKey(book.Id))
            {
                cache.Remove(book.Id);
            }
            BookAddedOrRemovedMessage msg = new BookAddedOrRemovedMessage(this, book);
            this.messenger.SendMessage<BookAddedOrRemovedMessage>(this, msg);
        }

        public async Task RemoveBook(BookshelfModel shelf, BookModel book)
        {
            await this.baseService.RemoveBook(shelf, book);
            //
            // Invalidate the cache and send a message
            //
            if (cache.ContainsKey(book.Id))
            {
                cache.Remove(book.Id);
            }
            BookAddedOrRemovedMessage msg = new BookAddedOrRemovedMessage(this, book);
            this.messenger.SendMessage<BookAddedOrRemovedMessage>(this, msg);
        }

        public IPagedCollection<WorkModel> Find(BookSearchType type, string term)
        {
            return this.baseService.Find(type, term);
        }

        public IPagedCollection<BookModel> GetBooksByYear(long userId, int year)
        {
            return this.baseService.GetBooksByYear(userId, year);
        }

        public IPagedCollection<BookModel> GetOwnedBooks(long userId)
        {
            return this.baseService.GetOwnedBooks(userId);
        }

        private void HandleReviewAddedOrEdited(object sender, ReviewAddedOrEditedMessage msg)
        {
            if (msg.Book != null && cache.ContainsKey(msg.Book.Id))
            {
                cache.Remove(msg.Book.Id);
            }
        }
    }
}
