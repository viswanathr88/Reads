using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(IAddBookViewModel))]
    public partial class AddBookPage : DataPage
    {
        public AddBookPage()
        {
            InitializeComponent();
        }
    }
}