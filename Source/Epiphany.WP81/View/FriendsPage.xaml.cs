using System.ComponentModel;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using Windows.UI.Xaml.Controls;
using System;
using System.Net;
using Epiphany.Strings;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendsPage : DataPage
    {
        private readonly DataContextWrapper<IFriendsViewModel> Context;
        public FriendsPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
            Context = new DataContextWrapper<IFriendsViewModel>(DataContext);
            RegisterPropertyChanged();

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
                    if (code == HttpStatusCode.Forbidden || code == HttpStatusCode.Unauthorized)
                    {
                        this.errorText.Text = AppStrings.FriendsPagePermissionDeniedErrorText;
                        this.errorText.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.errorText.Text = AppStrings.FriendsPageGenericErrorText;
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

        private async void Friend_Clicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                var userItemVM = e.ClickedItem as IUserItemViewModel;
                await App.Navigate(typeof(ProfilePage), userItemVM.Item);
            }
        }
    }
}
