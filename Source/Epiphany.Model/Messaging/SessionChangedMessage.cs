using Epiphany.Model.Authentication;

namespace Epiphany.Model.Messaging
{
    class SessionChangedMessage : IMessage
    {
        private readonly object sender;
        private readonly Session session;

        public SessionChangedMessage(object sender, Session session)
        {
            this.sender = sender;
            this.session = session;
        }

        public object Sender
        {
            get
            {
                return this.sender;
            }
        }

        public Session Session
        {
            get
            {
                return this.session;
            }
        }
    }
}
