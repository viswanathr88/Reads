using System.ComponentModel;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Epiphany.ViewModel;
using Windows.UI.Popups;
using System.Net;
using System;
using Epiphany.Strings;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BooksPage : DataPage
    {
        private readonly DataContextWrapper<IBooksViewModel> Context;
        public BooksPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            RegisterPropertyChanged();
            Context = new DataContextWrapper<IBooksViewModel>(DataContext);
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnViewModelPropertyChanged(sender, e);

            if (e.PropertyName == nameof(IDataViewModel.Error))
            {
                var error = Context.ViewModel.Error as Exception;
                HttpStatusCode? code = ((Context.ViewModel.Error as WebException)?.Response as HttpWebResponse)?.StatusCode;

                if (code.HasValue)
                {
                    if (code == HttpStatusCode.Forbidden)
                    {
                        this.errorText.Text = AppStrings.BooksInShelfPermissionDeniedErrorMessage;
                        this.errorText.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.errorText.Text = AppStrings.BooksInShelfGenericErrorMessage;
                        this.errorText.Visibility = Visibility.Visible;
                    }
                }
            }
            else if (e.PropertyName == nameof(IDataViewModel.IsLoading))
            {
                if (Context.DataViewModel.IsLoading)
                {
                    this.errorText.Visibility = Visibility.Collapsed;
                    this.errorText.Text = "";
                }
            }
        }

        private void ScrollToTop(object sender, RoutedEventArgs e)
        {
            if (this.booksList.Items.Count > 0)
            {
                this.booksList.ScrollIntoView(this.booksList.Items[0]);
            }
        }

        private async void Book_Click(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                var parameter = (e.ClickedItem as BookItemViewModel).Item;
                await App.Navigate(typeof(BookPage), parameter);
            }
        }

        private void Home_Clicked(object sender, RoutedEventArgs e)
        {
            while (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
