using Epiphany.Model.Messaging;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Epiphany.Model.Tests.Messaging
{
    [TestClass]
    public class MessengerTests
    {
        [TestMethod]
        public void FirstAccessTest()
        {
            Assert.IsNotNull(Messenger.Instance);
        }

        [TestMethod]
        public void SelfSkipTest()
        {
            bool actionCalled = false;
            
            Messenger.Instance.Subscribe<MockMessage>(this, (sender, message) =>
            {
                actionCalled = true;
            });

            Messenger.Instance.SendMessage<MockMessage>(this, new MockMessage(this));

            Assert.IsFalse(actionCalled);
        }

        [TestMethod]
        public void ReceiverTest()
        {
            MockMessageReceiver receiver = new MockMessageReceiver(Messenger.Instance);          
            Messenger.Instance.SendMessage<MockMessage>(this, new MockMessage(this));
            Assert.IsTrue(receiver.MessageReceived);
        }

        [TestMethod]
        public void MultipleReceiverTest()
        {
            MockMessageReceiver receiver1 = new MockMessageReceiver(Messenger.Instance);
            MockMessageReceiver receiver2 = new MockMessageReceiver(Messenger.Instance);
            MockMessageReceiver receiver3 = new MockMessageReceiver(Messenger.Instance);

            Messenger.Instance.SendMessage<MockMessage>(this, new MockMessage(this));
            Assert.IsTrue(receiver1.MessageReceived);
            Assert.IsTrue(receiver2.MessageReceived);
            Assert.IsTrue(receiver3.MessageReceived);
        }

        [TestMethod]
        public void UnsubscribeTest()
        {
            MockMessageReceiver receiver = new MockMessageReceiver(Messenger.Instance);
            Messenger.Instance.SendMessage<MockMessage>(this, new MockMessage(this));
            Assert.IsTrue(receiver.MessageReceived);

            receiver.MessageReceived = false;
            receiver.Unsubscribe();
            Messenger.Instance.SendMessage<MockMessage>(this, new MockMessage(this));
            Assert.IsFalse(receiver.MessageReceived);
        }
    }


    class MockMessageReceiver
    {
        public bool MessageReceived = false;
        private IMessenger messenger;

        public MockMessageReceiver(IMessenger messenger)
        {
            this.messenger = messenger;

            this.messenger.Subscribe<MockMessage>(this, (sender, message) =>
            {
                MessageReceived = true;
            });
        }

        public void Unsubscribe()
        {
            this.messenger.Unsubscribe<MockMessage>(this);
        }
    }
}
