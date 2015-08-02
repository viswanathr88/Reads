using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(IHomeViewModel))]
    public partial class HomePage : DataPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
    }
}