using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using Microsoft.Phone.Controls;

namespace Epiphany.View
{
    [SourceModel(typeof(IBookshelvesViewModel))]
    public partial class BookshelvesPage : DataPage
    {
        public BookshelvesPage()
        {
            InitializeComponent();
        }
    }
}