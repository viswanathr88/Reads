using Epiphany.Model.Collections;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Interface for a group service
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Gets the groups for a user
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <returns>collection of groups</returns>
        IPagedCollection<GroupModel> GetGroups(UserModel user);
        /// <summary>
        /// Gets a group
        /// </summary>
        /// <param name="groupId">id of the group</param>
        /// <returns>group</returns>
        Task<GroupModel> GetGroup(int groupId);
        /// <summary>
        /// Gets topics in a group folder
        /// </summary>
        /// <param name="groupFolder">group folder to fetch topics from</param>
        /// <returns></returns>
        IPagedCollection<TopicModel> GetTopics(int groupId, int groupFolderId);
        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="topicId">id of the topic</param>
        /// <returns>topic</returns>
        Task<TopicModel> GetTopic(int topicId);
        /// <summary>
        /// Gets comments for a topic
        /// </summary>
        /// <param name="topic">topic to get comments on</param>
        /// <returns>collection of comments</returns>
        IPagedCollection<CommentModel> GetComments(TopicModel topic);
        /// <summary>
        /// Create a new topic
        /// </summary>
        /// <param name="topic">topic to be created</param>
        /// <param name="body">body of the topic</param>
        Task CreateTopic(TopicModel topic, string body);
        /// <summary>
        /// Add a comment to a topic
        /// </summary>
        /// <param name="topic">topic</param>
        /// <param name="comment">comment</param>
        Task AddComment(TopicModel topic, CommentModel comment);
        /// <summary>
        /// Join a group
        /// </summary>
        /// <param name="group">group to join</param>
        Task JoinGroup(GroupModel group);
        /// <summary>
        /// Find groups
        /// </summary>
        /// <param name="term">search term</param>
        /// <returns>collection of groups</returns>
        IPagedCollection<GroupModel> Find(string term);
    }
}
