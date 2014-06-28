using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Interface for a notification service
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Gets the notifications for the current user
        /// </summary>
        /// <returns>list of notifications</returns>
        Task<IEnumerable<NotificationModel>> GetNotifications();
    }
}
