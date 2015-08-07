
using Epiphany.View.Attributes;
using Epiphany.ViewModel;
namespace Epiphany.View
{
    [SourceModel(typeof(IBooksViewModel))]
    public partial class BooksPage : DataPage
    {
        public BooksPage()
        {
            InitializeComponent();
        }
    }
}