using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View.View
{
    [SourceModel(typeof(IProfileViewModel))]
    public partial class ProfilePage : DataPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}