using Epiphany.Model.Messaging;

namespace Epiphany.Model.Tests.Messaging
{
    public class MockMessage : IMessage
    {
        private readonly object sender;

        public MockMessage(object sender)
        {
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
