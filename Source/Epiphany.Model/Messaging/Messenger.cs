using System;
using System.Collections.Generic;

namespace Epiphany.Model.Messaging
{
    class Messenger : IMessenger
    {
        private readonly IDictionary<Type, IList<IMessageSubscription>> subscriptionMap = new Dictionary<Type, IList<IMessageSubscription>>();
        private static volatile IMessenger instance;
        private readonly object _lock = new object();
        private readonly static object syncRoot = new object();

        private Messenger()
        {

        }

        public static IMessenger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Messenger();
                    }
                }
                return instance;
            }
        }

        public void Subscribe<TMessage>(object source, Action<object, TMessage> messageHandler) where TMessage : class, IMessage
        {
            lock (_lock)
            {
                IList<IMessageSubscription> subscriptions;

                if (!subscriptionMap.TryGetValue(typeof(TMessage), out subscriptions))
                {
                    subscriptions = new List<IMessageSubscription>();
                    subscriptionMap[typeof(TMessage)] = subscriptions;
                }

                IMessageSubscription subscription = new MessageSubscription<TMessage>(source, messageHandler);
                subscriptions.Add(subscription);
            }
        }

        public void Unsubscribe<TMessage>(object source) where TMessage : class, IMessage
        {
            lock (_lock)
            {
                if (subscriptionMap.ContainsKey(typeof(TMessage)))
                {
                    IList<IMessageSubscription> subscriptions = subscriptionMap[typeof(TMessage)];
                    int index = 0;
                    bool found = false;
                    foreach (IMessageSubscription subscription in subscriptions)
                    {
                        if (subscription.Source == source)
                        {
                            found = true;
                            break;
                        }
                        else
                        {
                            index++;
                        }
                    }

                    if (found)
                    {
                        subscriptions.RemoveAt(index);
                    }
                }
            }
        }

        public void SendMessage<TMessage>(object sender, TMessage message) where TMessage : class, IMessage
        {
            lock (_lock)
            {
                if (subscriptionMap.ContainsKey(typeof(TMessage)))
                {
                    IList<IMessageSubscription> subscriptions = subscriptionMap[typeof(TMessage)];
                    foreach (IMessageSubscription subscription in subscriptions)
                    {
                        if (subscription.Source != sender)
                        {
                            subscription.Deliver(message);
                        }
                    }
                }
            }
        }
    }
}
