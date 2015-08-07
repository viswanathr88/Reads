using Epiphany.View.Attributes;
using Epiphany.ViewModel;
using Microsoft.Phone.Controls;
using System.Windows;
using System.Windows.Navigation;

namespace Epiphany.View
{
    [SourceModel(typeof(IEventsViewModel))]
    public partial class EventsPage : DataPage
    {
        public EventsPage()
        {
            InitializeComponent();
        }
    }
}