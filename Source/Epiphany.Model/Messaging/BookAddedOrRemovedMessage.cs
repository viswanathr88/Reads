
namespace Epiphany.Model.Messaging
{
    class BookAddedOrRemovedMessage : GenericMessage<BookModel>
    {
        public BookAddedOrRemovedMessage(object sender, BookModel book)
            : base(sender, book)
        {

        }
    }
}
