using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(ISettingsViewModel))]
    public partial class SettingsPage : DataPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }
}