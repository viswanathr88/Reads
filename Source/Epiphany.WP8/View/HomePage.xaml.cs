using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(HomeViewModel))]
    public partial class HomePage : DataPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Remove any previous pages in the backstack
            if (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }

            base.OnNavigatedTo(e);
        }
    }
}