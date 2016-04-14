using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(AuthorViewModel))]
    public partial class AuthorPage : DataPage
    {
        public AuthorPage()
        {
            InitializeComponent();
        }
    }
}