using Epiphany.View.Attributes;
using Epiphany.ViewModel;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=321224

namespace Epiphany.UI.Pages
{
    [SourceModel(typeof(HomeViewModel))]
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class HomePage : DataPage
    {
        public HomePage()
        {
            this.InitializeComponent();
        }
    }
}
