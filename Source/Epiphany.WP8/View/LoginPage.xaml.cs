using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(LogonViewModel))]
    public partial class LoginPage : DataPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}