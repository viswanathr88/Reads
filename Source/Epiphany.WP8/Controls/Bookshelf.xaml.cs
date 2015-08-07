using System.Windows;
using System.Windows.Controls;

namespace Epiphany.View.Controls
{
    public partial class Bookshelf : UserControl
    {
        public Bookshelf()
        {
            InitializeComponent();
        }

        public string ShelfName
        {
            get { return (string)GetValue(ShelfNameProperty); }
            set { SetValue(ShelfNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShelfName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShelfNameProperty =
            DependencyProperty.Register("ShelfName", typeof(string), typeof(Bookshelf), new PropertyMetadata(string.Empty));

        public int NumberOfBooks
        {
            get { return (int)GetValue(NumberOfBooksProperty); }
            set { SetValue(NumberOfBooksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NumberOfBooks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberOfBooksProperty =
            DependencyProperty.Register("NumberOfBooks", typeof(int), typeof(Bookshelf), new PropertyMetadata(0));

        
    }
}
