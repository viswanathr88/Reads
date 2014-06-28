using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiphany.Model.Messaging
{
    class AddReviewMessage : IMessage
    {
        private readonly object sender;
        private readonly BookModel book;
        private readonly ReviewModel review;

        public AddReviewMessage(object sender, BookModel book, ReviewModel review)
        {
            this.sender = sender;
            this.review = review;
            this.book = book;
        }

        public object Sender
        {
            get
            {
                return this.sender;
            }
        }

        public BookModel Book
        {
            get
            {
                return this.book;
            }
        }

        public ReviewModel Review
        {
            get
            {
                return this.review;
            }
        }
    }
}
