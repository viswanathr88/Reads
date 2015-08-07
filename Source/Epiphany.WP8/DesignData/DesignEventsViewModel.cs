using Epiphany.Model;
using Epiphany.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignEventsViewModel : DataViewModel, IEventsViewModel
    {
        public DesignEventsViewModel()
        {
            IsLoading = true;
            Events = new List<LiteraryEventModel>();

            
        }

        public IList<LiteraryEventModel> Events
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

        public override Task LoadAsync()
        {
            return Task.FromResult(true);
        }
    }
}
