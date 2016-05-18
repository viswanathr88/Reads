using Epiphany.Model.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{

    public enum FeedUpdateType
    {
        all,
        books,
        reviews,
        statuses
    };

    public enum FeedUpdateFilter
    {
        friends,
        following,
        top_friends
    };

    /// <summary>
    /// Interface for a user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a user profile
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>Profile</returns>
        Task<ProfileModel> GetProfileAsync(int id);
        /// <summary>
        /// Gets a user's friends
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>user collection</returns>
        IPagedCollection<UserModel> GetFriends(int id);
        /// <summary>
        /// Gets the recent updates from friends
        /// </summary>
        /// <returns>collection of feed item models</returns>
        Task<IEnumerable<FeedItemModel>> GetFriendUpdatesAsync(FeedUpdateType type, FeedUpdateFilter filter);
        /// <summary>
        /// Add a user as a friend
        /// </summary>
        /// <param name="profile">profile of the user to be added</param>
        Task AddFriend(ProfileModel profile);
        /// <summary>
        /// Follow a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task FollowUser(ProfileModel user);
        /// <summary>
        /// Unfollow user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UnfollowUser(ProfileModel user);
    }
}
