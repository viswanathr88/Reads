using Epiphany.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.UI.Pages
{
    [SourceModel(typeof(LogonViewModel))]
    /// <summary>
    /// Represents the Login Page
    /// </summary>
    public sealed partial class LoginPage : DataPage
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }
    }
}
