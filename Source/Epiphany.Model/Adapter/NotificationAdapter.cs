using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class NotificationAdapter : IAdapter<NotificationModel, GoodreadsNotification>
    {
        public NotificationModel Convert(GoodreadsNotification item)
        {
            NotificationModel model = new NotificationModel(item);
            return model;
        }
    }
}
