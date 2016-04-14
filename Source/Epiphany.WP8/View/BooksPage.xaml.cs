
using Epiphany.View.Attributes;
using Epiphany.ViewModel;
namespace Epiphany.View
{
    [SourceModel(typeof(BooksViewModel))]
    public partial class BooksPage : DataPage
    {
        public BooksPage()
        {
            InitializeComponent();
        }
    }
}