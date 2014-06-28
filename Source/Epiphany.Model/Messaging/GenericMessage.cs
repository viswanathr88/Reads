
namespace Epiphany.Model.Messaging
{
    class GenericMessage<T> : MessageBase
    {
        private readonly T content;

        public GenericMessage(object sender, T content)
            : base(sender)
        {
            this.content = content;
        }

        public T Content
        {
            get
            {
                return this.content;
            }
        }
    }
}
