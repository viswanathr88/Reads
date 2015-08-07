using Epiphany.View;
using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(IFriendsViewModel))]
    public partial class FriendsPage : DataPage
    {
        public FriendsPage()
        {
            InitializeComponent();
        }
    }
}