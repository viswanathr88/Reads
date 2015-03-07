using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using Windows.UI.Xaml.Navigation;

namespace Epiphany.UI.Pages
{
    [SourceModel(typeof(HomeViewModel))]
    public sealed partial class HomePage : DataPage
    {
        public HomePage()
        {
            this.InitializeComponent();
        }
    }
}
