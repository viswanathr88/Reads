using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignEventsViewModel : DesignBaseViewModel, IEventsViewModel
    {
        public DesignEventsViewModel()
        {
            IsLoading = true;
            Events = new List<IEventItemViewModel>();
        }

        public IList<IEventItemViewModel> Events
        {
            get;
            private set;
        }

        public IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents
        {
            get { return null; }
        }

        public ICommand Refresh
        {
            get { return null; }
        }

        public LiteraryEventModel SelectedEvent
        {
            get;
            set;
        }
    }
}
