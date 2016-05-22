using Windows.UI.Xaml;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BooksPage : DataPage
    {
        public BooksPage()
        {
            this.InitializeComponent();

        }

        private void ScrollToTop(object sender, RoutedEventArgs e)
        {
            if (this.booksList.Items.Count > 0)
            {
                this.booksList.ScrollIntoView(this.booksList.Items[0]);
            }
        }
    }
}
