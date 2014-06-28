using System;

namespace Epiphany.Model.Messaging
{
    abstract class MessageBase : IMessage
    {
        private readonly object sender;

        public MessageBase(object sender)
        {
            if (sender == null)
            {
                throw new ArgumentNullException();
            }

            this.sender = sender;
        }
        public object Sender
        {
            get
            {
                return this.sender;
            }
        }
    }
}
