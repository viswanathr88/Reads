using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using System;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthorPage : DataPage
    {
        public AuthorPage()
        {
            this.InitializeComponent();
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnViewModelPropertyChanged(sender, e);

            if (e.PropertyName == nameof(IDataViewModel.IsLoaded))
            {
                if (GetViewModel<IDataViewModel>().IsLoaded)
                {
                    UpdatePinState();
                }
            }
        }

        private void Home_Clicked(object sender, RoutedEventArgs e)
        {
            while (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void Book_Clicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                var bookItem = e.ClickedItem as IBookItemViewModel;
                await App.Navigate(typeof(BookPage), bookItem.Item, new SlideNavigationTransitionInfo());
            }
        }

        private async void Pin_Clicked(object sender, RoutedEventArgs e)
        {
            string tileId = GetTileId();
            if (!SecondaryTile.Exists(tileId))
            {
                var vm = GetViewModel<IAuthorViewModel>();
                var tile = new SecondaryTile(
                    tileId,
                    vm.Name,
                    $"id={vm.Parameter.Id}",
                    new Uri("ms-appx:///Assets/Square71x71Logo.scale-240.png"),
                    TileSize.Default);
                await tile.RequestCreateAsync();
            }
            else
            {
                var tile = new SecondaryTile(tileId);
                await tile.RequestDeleteAsync();
            }

            UpdatePinState();
        }

        private void Unpin_Clicked(object sender, RoutedEventArgs e)
        {
            string tileId = GetTileId();
        }

        private void UpdatePinState()
        {
            string tileId = GetTileId();

            pinButton.Visibility = (SecondaryTile.Exists(tileId)) ? Visibility.Collapsed : Visibility.Visible;
            unpinButton.Visibility = (pinButton.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
        }

        private string GetTileId()
        {
            long id = GetViewModel<IAuthorViewModel>().Parameter.Id;
            return $"author_{id}";
        }
    }
}
