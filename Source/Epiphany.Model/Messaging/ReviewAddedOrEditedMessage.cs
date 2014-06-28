
namespace Epiphany.Model.Messaging
{
    class ReviewAddedOrEditedMessage : GenericMessage<ReviewModel>
    {
        private readonly BookModel book;

        public ReviewAddedOrEditedMessage(object sender, ReviewModel review, BookModel book)
            : base(sender, review)
        {
            this.book = book;
        }

        public BookModel Book
        {
            get
            {
                return this.book;
            }
        }
    }
}
