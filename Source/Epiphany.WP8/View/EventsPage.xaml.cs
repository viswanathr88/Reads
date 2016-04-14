using Epiphany.View.Attributes;
using Epiphany.ViewModel;

namespace Epiphany.View
{
    [SourceModel(typeof(EventsViewModel))]
    public partial class EventsPage : DataPage
    {
        public EventsPage()
        {
            InitializeComponent();
        }
    }
}