using Epiphany.Xml;

namespace Epiphany.Model
{
    public sealed class NotificationModel : Entity<int>
    {
        private readonly int id;
        private readonly GoodreadsNotification notification;

        public NotificationModel(int id)
        {
            this.id = id;
            this.notification = new GoodreadsNotification();
        }

        internal NotificationModel(GoodreadsNotification notification)
        {
            this.notification = notification;
            this.id = notification.Id;
        }

        public override int Id
        {
            get
            {
                return this.id;
            }
        }
    }
}
