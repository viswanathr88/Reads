using System;

namespace Epiphany.Model.Messaging
{
    class MessageSubscription<TMessage> : IMessageSubscription where TMessage : class, IMessage
    {
        private readonly Action<object, TMessage> handler;
        private readonly object source;

        public MessageSubscription(object source, Action<object, TMessage> messageHandler)
        {
            if (source == null || messageHandler == null)
            {
                throw new ArgumentNullException();
            }

            this.source = source;
            this.handler = messageHandler;
        }

        public void Deliver(IMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            if (!(message is TMessage))
            {
                throw new ArgumentException("Message is not the correct type");
            }

            handler.Invoke(message.Sender, message as TMessage);
        }

        public object Source
        {
            get
            {
                return this.source;
            }
        }
    }
}
