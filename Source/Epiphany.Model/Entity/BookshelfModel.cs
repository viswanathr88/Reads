
namespace Epiphany.Model
{
    public sealed class BookshelfModel : Entity<int>
    {
        private int id;
        private string name;
        private int booksCount;
        private string description;
        private bool isExclusive;
        private bool isFeatured;
        private bool isSticky;

        public static BookshelfModel Create(string name, bool isFeatured, bool isExclusive)
        {
            BookshelfModel shelf = new BookshelfModel();
            shelf.Name = name;
            shelf.IsFeatured = isFeatured;
            shelf.IsExclusive = isExclusive;
            return shelf;
        }

        public BookshelfModel(int id)
        {
            this.id = id;
        }

        private BookshelfModel()
        {

        }

        public override int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == value) return;
                this.name = value;
            }
        }

        public int BooksCount
        {
            get
            {
                return this.booksCount;
            }
            set
            {
                if (this.booksCount == value) return;
                this.booksCount = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (this.description == value) return;
                this.description = value;
            }
        }

        public bool IsExclusive
        {
            get
            {
                return this.isExclusive;
            }
            set
            {
                if (this.isExclusive == value) return;
                this.isExclusive = value;
            }
        }

        public bool IsFeatured
        {
            get
            {
                return this.isFeatured;
            }
            set
            {
                if (this.isFeatured == value) return;
                this.isFeatured = value;
            }
        }

        public bool IsSticky
        {
            get
            {
                return this.isSticky;
            }
            set
            {
                if (this.isSticky == value) return;
                this.isSticky = value;
            }
        }
    }
}
