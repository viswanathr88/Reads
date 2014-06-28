using Epiphany.Model.Collections;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    public enum BookSortType
    {
        date_read,
        date_added,
        title,
        author,
        avg_rating,
        date_started,
        cover,
        num_pages,
        num_ratings,
        owned,
        year_pub,
        rating,
        read_count,
        review
    };

    public enum BookSearchType
    {
        All,
        Title,
        Author
    };

    public enum BookSortOrder
    {
        a,
        d
    };

    /// <summary>
    /// Interface for a book service
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Gets the book
        /// </summary>
        /// <param name="id">id of the book</param>
        /// <returns>book</returns>
        Task<BookModel> GetBook(int id);
        /// <summary>
        /// Gets the books by an author
        /// </summary>
        /// <param name="author">author model</param>
        /// <returns>collection of books</returns>
        IPagedCollection<BookModel> GetBooks(AuthorModel author);
        /// <summary>
        /// Gets all the books in a bookshelf
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <param name="shelfName">name of the bookshelf</param>
        /// <returns>book collection</returns>
        IPagedCollection<BookModel> GetBooks(int userId, string shelfName, BookSortType sortType, BookSortOrder order);
        /// <summary>
        /// Adds a book to the given shelf
        /// </summary>
        /// <param name="shelf">bookshelf to be added to</param>
        /// <param name="book">book to be added</param>
        Task AddBook(BookshelfModel shelf, BookModel book);
        /// <summary>
        /// Remove a book from a given shelf
        /// </summary>
        /// <param name="shelf">bookshelf to be removed from</param>
        /// <param name="book">the book to be removed</param>
        Task RemoveBook(BookshelfModel shelf, BookModel book);
        /// <summary>
        /// Find books
        /// </summary>
        /// <param name="type">all|title|author</param>
        /// <param name="term">search term</param>
        /// <returns>collection of books</returns>
        IPagedCollection<WorkModel> Find(BookSearchType type, string term);
    }
}
