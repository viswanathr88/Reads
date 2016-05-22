// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

using Epiphany.View.Navigation;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookPage : DataPage
    {
        public BookPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
        }

        protected override void LoadState(object sender, LoadStateEventArgs e)
        {
            base.LoadState(sender, e);

            // Restore pivot position
            if (this.pivotHeaderList != null && e.PageState != null && e.PageState.ContainsKey("PivotSelectedIndex"))
            {
                this.pivotHeaderList.SelectedIndex = (int)e.PageState["PivotSelectedIndex"];
            }
        }

        protected override void SaveState(object sender, SaveStateEventArgs e)
        {
            base.SaveState(sender, e);

            // Save pivot position
            if (this.pivotHeaderList != null && e.PageState != null)
            {
                e.PageState["PivotSelectedIndex"] = this.pivotHeaderList.SelectedIndex;

                // Reset pivot position
                this.pivotHeaderList.SelectedIndex = 0;
            }
        }

        private async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var bookItem = e.AddedItems[0] as BookItemViewModel;

                await App.Navigate(typeof(BookPage), bookItem.Item, new CommonNavigationTransitionInfo());
            }
        }
    }
}
