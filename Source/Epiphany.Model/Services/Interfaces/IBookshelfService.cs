using Epiphany.Model.Collections;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Interface for a bookshelf service
    /// </summary>
    public interface IBookshelfService
    {
        /// <summary>
        /// Gets the bookshelves for a user
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <returns>collection of bookshelves</returns>
        IPagedCollection<BookshelfModel> GetBookshelves(long userId);
        /// <summary>
        /// Add a new shelf
        /// </summary>
        /// <param name="shelf">shelf to be added</param>
        Task AddShelf(BookshelfModel shelf);
        /// <summary>
        /// Remove shelf for a user
        /// </summary>
        /// <param name="shelf">shelf to be removed</param>
        Task RemoveShelf(BookshelfModel shelf);
    }
}
