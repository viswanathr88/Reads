using System;

namespace Epiphany.Model.Authentication
{
    public class SessionChangedEventArgs : EventArgs
    {
        private Session session;

        public SessionChangedEventArgs(Session session)
        {
            this.session = session;
        }

        public Session Session
        {
            get { return this.session; }
        }
    }
}
