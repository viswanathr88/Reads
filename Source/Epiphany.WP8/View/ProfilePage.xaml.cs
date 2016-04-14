using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(ProfileViewModel))]
    public partial class ProfilePage : DataPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}