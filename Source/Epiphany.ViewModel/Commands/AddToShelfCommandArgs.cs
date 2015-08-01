using Epiphany.Model;
using Epiphany.ViewModel.Collections;

namespace Epiphany.ViewModel.Commands
{
    public class AddToShelvesCommandArgs
    {
        private readonly BookModel book;
        private readonly DeltaList<string> changesList;

        public AddToShelvesCommandArgs(BookModel book, DeltaList<string> changesList)
        {
            this.book = book;
            this.changesList = changesList;
        }

        public BookModel Book
        {
            get { return this.book; }
        }

        public DeltaList<string> ChangesList
        {
            get { return this.changesList; }
        }
    }
}
