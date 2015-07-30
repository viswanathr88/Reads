using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(ILogonViewModel))]
    public partial class LoginPage : DataPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}