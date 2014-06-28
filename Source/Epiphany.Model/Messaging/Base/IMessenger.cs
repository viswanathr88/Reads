using System;

namespace Epiphany.Model.Messaging
{
    /// <summary>
    /// An interface for a Messenger
    /// </summary>
    interface IMessenger
    {
        /// <summary>
        /// Subscribe to a message of particular type
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="messageHandler"></param>
        void Subscribe<TMessage>(object source, Action<object, TMessage> messageHandler) where TMessage : class, IMessage;
        /// <summary>
        /// Unsubscribe to a message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        void Unsubscribe<TMessage>(object source) where TMessage : class, IMessage;
        /// <summary>
        /// Send a message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="message"></param>
        void SendMessage<TMessage>(object sender, TMessage message) where TMessage : class, IMessage;
    }
}
