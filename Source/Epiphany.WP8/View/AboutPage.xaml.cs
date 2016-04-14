
using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(AboutViewModel))]
    public partial class AboutPage : DataPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}