
using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using Microsoft.Phone.Controls;

namespace Epiphany.View
{
    [SourceModel(typeof(IAboutViewModel))]
    public partial class AboutPage : DataPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}