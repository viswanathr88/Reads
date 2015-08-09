using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using Microsoft.Phone.Controls;

namespace Epiphany.View
{
    [SourceModel(typeof(IAuthorViewModel))]
    public partial class AuthorPage : DataPage
    {
        public AuthorPage()
        {
            InitializeComponent();
        }
    }
}