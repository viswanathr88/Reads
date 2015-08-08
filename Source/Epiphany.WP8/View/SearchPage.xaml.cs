using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using System.Windows;

namespace Epiphany.View
{
    [SourceModel(typeof(ISearchViewModel))]
    public partial class SearchPage : DataPage
    {
        public SearchPage()
        {
            InitializeComponent();
            Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.searchBox.Text))
            {
                this.searchBox.Focus();
            }
        }
    }
}