using Epiphany.Logging;
using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.UI.Pages
{
    [SourceModel(typeof(ProfileViewModel))]
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : DataPage
    {
        public ProfilePage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Log.Instance.Debug(sender.GetHashCode().ToString());
        }
    }
}
