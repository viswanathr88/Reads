using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public class EventsViewModel : DataViewModel, IEventsViewModel
    {
        private readonly IEventService eventService;
        private readonly IUrlLauncher urlLauncher;
        private readonly ILocationService locationService;

        private LiteraryEventModel selectedEvent;
        private IList<LiteraryEventModel> events;
        private readonly IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> fetchEventsCommand;

        public EventsViewModel(IEventService eventService, ILocationService locationService, IUrlLauncher urlLauncher)
        {
            this.eventService = eventService;
            this.urlLauncher = urlLauncher;
            this.locationService = locationService;

            this.fetchEventsCommand = new FetchEventsCommand(eventService, locationService);
            this.fetchEventsCommand.Executing += OnCommandExecuting;
            this.fetchEventsCommand.Executed += OnCommandExecuted;
        }

        public IList<LiteraryEventModel> Events
        {
            get { return this.events; }
            private set
            {
                if (this.events == value) return;
                this.events = value;
                RaisePropertyChanged(() => Events);
            }
        }

        public LiteraryEventModel SelectedEvent
        {
            get { return this.selectedEvent; }
            set
            {
                if (this.selectedEvent == value) return;
                this.selectedEvent = value;
                this.urlLauncher.Launch(this.selectedEvent.Link);
                this.selectedEvent = null;
                RaisePropertyChanged(() => SelectedEvent);
            }
        }

        public void Load()
        {
            
        }

        public IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents
        {
            get { return this.fetchEventsCommand; }
        }

        public ICommand Refresh
        {
            get { return this.fetchEventsCommand; }
        }

        private void OnCommandExecuted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                Events = new ObservableCollection<LiteraryEventModel>(this.fetchEventsCommand.Result);
                IsLoaded = true;
            }
        }

        private void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        public override async Task LoadAsync()
        {
            if (this.fetchEventsCommand.CanExecute(VoidType.Empty))
            {
                await this.fetchEventsCommand.ExecuteAsync(VoidType.Empty);
            }
        }
    }
}
