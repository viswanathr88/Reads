using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Epiphany.View.Controls
{
    public class DeferredContentLoader : ContentControl
    {
        public bool IsLoaded
        {
            get { return (bool)GetValue(IsLoadedProperty); }
            set { SetValue(IsLoadedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadedProperty =
            DependencyProperty.Register("IsLoaded", typeof(bool), typeof(DeferredContentLoader), new PropertyMetadata(false, OnContentLoadedChanged));

        public DataTemplate DeferredContentTemplate
        {
            get { return (DataTemplate)GetValue(DeferredContentTemplateProperty); }
            set { SetValue(DeferredContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty DeferredContentTemplateProperty =
            DependencyProperty.Register("DeferredContentTemplate",
            typeof(DataTemplate), typeof(DeferredContentLoader), null);


        private static void OnContentLoadedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DeferredContentLoader presenter = d as DeferredContentLoader;
            bool isLoaded = (bool)e.NewValue;

            if (isLoaded)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() => presenter.ShowContent());
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
