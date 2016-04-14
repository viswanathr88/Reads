using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(FriendsViewModel))]
    public partial class FriendsPage : DataPage
    {
        public FriendsPage()
        {
            InitializeComponent();
        }
    }
}