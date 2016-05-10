using Epiphany.Model.Adapter;
using Epiphany.Model.DataSources;
using Epiphany.Web;
using Epiphany.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    class NotificationService : INotificationService
    {
        private readonly IWebClient webClient;
        private readonly IAdapter<NotificationModel, GoodreadsNotification> adapter;

        public NotificationService(IWebClient webClient)
        {
            this.webClient = webClient;
            this.adapter = new NotificationAdapter();
        }

        public async Task<IEnumerable<NotificationModel>> GetNotifications()
        {
            // Create the data source and get the notifications
            var ds = new DataSource<GoodreadsNotifications>(webClient);
            ds.SourceUrl = ServiceUrls.NotificationsUrl;
            ds.Parameters["body_format"] = "plain";
            ds.RequiresAuthentication = true;
            ds.Returns = (response) => response.Notifications;
            
            GoodreadsNotifications notifications = await ds.GetAsync();

            // Iterate over the notifications and convert to model
            IList<NotificationModel> result = new List<NotificationModel>();
            foreach (GoodreadsNotification notification in notifications.Notifications)
            {
                result.Add(this.adapter.Convert(notification));
            }
            return result;
        }
    }
}
