using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    public interface IStatusService
    {
        /// <summary>
        /// Gets a UserStatus given an id
        /// </summary>
        /// <param name="id">id of the user status</param>
        /// <returns>UserStatus</returns>
        Task<UserStatusModel> GetUserStatus(long id);
        /// <summary>
        /// Update user status
        /// </summary>
        /// <param name="status">new status</param>
        Task UpdateUserStatus(UserStatusModel status);
        /// <summary>
        /// Like a user status
        /// </summary>
        /// <param name="status">status to like</param>
        Task LikeStatus(UserStatusModel status);
        /// <summary>
        /// Unlike a status
        /// </summary>
        /// <param name="status">status to unlike</param>
        Task UnlikeStatus(UserStatusModel status);
        /// <summary>
        /// Add a comment to a user status
        /// </summary>
        /// <param name="status">status to add comment</param>
        /// <param name="comment">comment to add</param>
        Task AddComment(UserStatusModel status, CommentModel comment);
    }
}
