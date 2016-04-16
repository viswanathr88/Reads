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
    public class EventsViewModel : DataViewModel<VoidType>
    {
        private readonly IEventService eventService;
        private readonly IDeviceServices deviceServices;

        private LiteraryEventModel selectedEvent;
        private IList<LiteraryEventModel> events;
        private readonly IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> fetchEventsCommand;

        public EventsViewModel(IEventService eventService, IDeviceServices deviceServices)
        {
            this.eventService = eventService;
            this.deviceServices = deviceServices;

            this.fetchEventsCommand = new FetchEventsCommand(eventService, deviceServices);
            RegisterCommand(this.fetchEventsCommand, OnCommandExecuted);
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
                this.deviceServices.LaunchUrl(this.selectedEvent.Link);
                this.selectedEvent = null;
                RaisePropertyChanged(() => SelectedEvent);
            }
        }

        public IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents
        {
            get { return this.fetchEventsCommand; }
        }

        public ICommand Refresh
        {
            get { return this.fetchEventsCommand; }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            if (this.fetchEventsCommand.CanExecute(parameter))
            {
                await this.fetchEventsCommand.ExecuteAsync(parameter);
            }
        }

        private void OnCommandExecuted(ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                Events = new ObservableCollection<LiteraryEventModel>(this.fetchEventsCommand.Result);
                IsLoaded = true;
            }
        }
    }
}
