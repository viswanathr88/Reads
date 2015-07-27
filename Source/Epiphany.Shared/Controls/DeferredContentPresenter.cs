using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Epiphany.Controls
{
    sealed class DeferredContentPresenter : ContentPresenter
    {
        public bool IsLoaded
        {
            get { return (bool)GetValue(IsLoadedProperty); }
            set { SetValue(IsLoadedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadedProperty =
            DependencyProperty.Register("IsLoaded", typeof(bool), typeof(DeferredContentPresenter), new PropertyMetadata(false, OnContentLoadedChanged));

        public DataTemplate DeferredContentTemplate
        {
            get { return (DataTemplate)GetValue(DeferredContentTemplateProperty); }
            set { SetValue(DeferredContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty DeferredContentTemplateProperty =
            DependencyProperty.Register("DeferredContentTemplate",
            typeof(DataTemplate), typeof(DeferredContentPresenter), null);


        private static void OnContentLoadedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DeferredContentPresenter presenter = d as DeferredContentPresenter;
            bool isLoaded = (bool)e.NewValue;

            if (isLoaded)
            {
                presenter.ShowContent();
            }
        }

        private void ShowContent()
        {
            if (DeferredContentTemplate != null)
            {
                Content = DeferredContentTemplate.LoadContent();
            }
        }
    }
}
