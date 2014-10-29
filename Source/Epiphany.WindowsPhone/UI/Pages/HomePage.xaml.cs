using Epiphany.Attributes;
using Epiphany.ViewModel;

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
