
namespace Epiphany.Model
{
    public class WorkModel : Entity<int>
    {
        private readonly int id;
        private string originalTitle;
        private BookModel book; 

        public WorkModel(int id)
        {
            this.id = id;
        }

        public override int Id
        {
            get
            {
                return this.id;
            }
        }

        public string OriginalTitle
        {
            get
            {
                return this.originalTitle;
            }
            set
            {
                if (this.originalTitle == value)
                {
                    return;
                }

                this.originalTitle = value;
            }
        }

        public BookModel Book
        {
            get
            {
                return this.book;
            }
            set
            {
                if (this.book == value)
                {
                    return;
                }

                this.book = value;
            }
        }
    }
}
