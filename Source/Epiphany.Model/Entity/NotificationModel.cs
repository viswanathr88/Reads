using Epiphany.Xml;

namespace Epiphany.Model
{
    public sealed class NotificationModel : Entity<long>
    {
        private readonly long id;
        private readonly GoodreadsNotification notification;

        public NotificationModel(long id)
        {
            this.id = id;
            this.notification = new GoodreadsNotification();
        }

        internal NotificationModel(GoodreadsNotification notification)
        {
            this.notification = notification;
            this.id = notification.Id;
        }

        public override long Id
        {
            get
            {
                return this.id;
            }
        }
    }
}
