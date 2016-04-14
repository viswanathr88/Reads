using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(BookViewModel))]
    public partial class BookPage : DataPage
    {
        public BookPage()
        {
            InitializeComponent();
        }
    }
}