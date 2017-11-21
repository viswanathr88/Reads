using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Interface for an author service
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Get an author
        /// </summary>
        /// <param name="id">id of the author</param>
        /// <returns>author</returns>
        Task<AuthorModel> GetAuthorAsync(long id);
        /// <summary>
        /// Become a fan of an author or stop being a fan
        /// </summary>
        /// <param name="author">author model</param>
        Task FlipFanshipAsync(AuthorModel author);
        /// <summary>
        /// Follow an author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        Task FollowAuthor(AuthorModel author);
    }
}
