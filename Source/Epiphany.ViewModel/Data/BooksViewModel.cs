
using System.Threading.Tasks;
namespace Epiphany.ViewModel
{
    public sealed class BooksViewModel : DataViewModel, IBooksViewModel
    {
        private int userId;
        private string userName;
        private string shelfName;

        public int UserId
        {
            get { return this.userId; }
            set
            {
                if (this.userId == value) return;
                this.userId = value;
                RaisePropertyChanged();
            }
        }

        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (this.userName == value) return;
                this.userName = value;
                RaisePropertyChanged();
            }
        }

        public string ShelfName
        {
            get { return this.shelfName; }
            set
            {
                if (this.shelfName == value) return;
                this.shelfName = value;
                RaisePropertyChanged();
            }
        }

        public override Task LoadAsync()
        {
            return Task.FromResult(true);
        }
    }
}
