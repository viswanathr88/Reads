
namespace Epiphany.Model.Messaging
{
    /// <summary>
    /// Interface for a message
    /// </summary>
    interface IMessage
    {
        object Sender
        {
            get;
        }
    }
}
