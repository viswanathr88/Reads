using Epiphany.Strings;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReviewPage : DataPage
    {
        private readonly DataContextWrapper<IReviewViewModel> Context;
        public ReviewPage()
        {
            this.InitializeComponent();
            Context = new DataContextWrapper<IReviewViewModel>(DataContext);
            RegisterPropertyChanged();
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnViewModelPropertyChanged(sender, e);

            if (e.PropertyName == nameof(IDataViewModel.IsLoaded))
            {
                UpdateShelves();
            }
        }

        private void UpdateShelves()
        {
            shelvesList.Blocks.Clear();

            // Create a paragraph
            var paragraph = new Paragraph();

            var header = new InlineUIContainer();
            header.Child = new TextBlock()
            {
                Text = AppStrings.ReviewShelvedAsText,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = App.Current.Resources["ApplicationForegroundThemeBrush"] as Brush,
                Margin = new Thickness(0, 0, 10, 0),
                TextLineBounds = TextLineBounds.Tight
            };
            paragraph.Inlines.Add(header);

            // Populate the shelves as buttons
            foreach (var shelf in Context.ViewModel.Shelves)
            {
                var container = new InlineUIContainer();
                var button = new Button()
                {
                    Content = new TextBlock()
                    {
                        Text = shelf.Name,
                        Foreground = App.Current.Resources["PhoneAccentBrush"] as Brush,
                        TextLineBounds = TextLineBounds.Tight
                    },

                    Style = App.Current.Resources["TextButtonStyle"] as Style,
                    MinHeight = 0,
                    MinWidth = 0,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Tag = shelf
                };
                button.Click += Shelf_Click;
                container.Child = button;
                paragraph.Inlines.Add(container);

                // Add a comma
                paragraph.Inlines.Add(new InlineUIContainer()
                {
                    Child = new TextBlock()
                    {
                        Text = ",",
                        Foreground = App.Current.Resources["ApplicationForegroundThemeBrush"] as Brush,
                        Margin = new Thickness(0,0,10,0),
                        TextLineBounds = TextLineBounds.Tight
                    }
                });
            }

            if (Context.ViewModel.Shelves.Count > 0)
            {
                // Remove the following comma
                paragraph.Inlines.RemoveAt(paragraph.Inlines.Count - 1);
            }
            
            shelvesList.Blocks.Add(paragraph);
        }

        private async void Shelf_Click(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            await App.Navigate(typeof(BooksPage), element.Tag as IBookshelfItemViewModel);
        }

        private async void Author_Clicked(object sender, ItemClickEventArgs e)
        {
            var authorVM = e.ClickedItem as IAuthorItemViewModel;
            await App.Navigate(typeof(AuthorPage), authorVM.Item);
        }

        private async void User_Click(object sender, RoutedEventArgs e)
        {
            await App.Navigate(typeof(ProfilePage), Context.ViewModel.User.Item, new ContinuumNavigationTransitionInfo());
        }

        private async void Book_Click(object sender, RoutedEventArgs e)
        {
            await App.Navigate(typeof(BookPage), Context.ViewModel.Book.Item, new SlideNavigationTransitionInfo());
        }
    }
}
