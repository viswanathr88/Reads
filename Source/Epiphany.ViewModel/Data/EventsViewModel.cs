using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class EventsViewModel : DataViewModel<VoidType>, IEventsViewModel
    {
        private readonly IEventService eventService;
        private readonly IDeviceServices deviceServices;

        private IEventItemViewModel selectedEvent;
        private IList<IEventItemViewModel> events;
        private readonly IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> fetchEventsCommand;

        public EventsViewModel(IEventService eventService, IDeviceServices deviceServices)
        {
            this.eventService = eventService;
            this.deviceServices = deviceServices;

            this.fetchEventsCommand = new FetchEventsCommand(eventService, deviceServices);
            RegisterCommand(this.fetchEventsCommand, OnCommandExecuted);
        }

        public IList<IEventItemViewModel> Events
        {
            get { return this.events; }
            private set
            {
                if (this.events == value) return;
                this.events = value;
                RaisePropertyChanged(() => Events);
            }
        }

        public IEventItemViewModel SelectedEvent
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

        protected override void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            base.OnCommandExecuting(sender, e);

            Events = new ObservableCollection<IEventItemViewModel>();
        }

        private void OnCommandExecuted(ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                Events = new ObservableCollection<IEventItemViewModel>();
                foreach (var ev in fetchEventsCommand.Result)
                {
                    Events.Add(new EventItemViewModel(ev));
                }
                IsLoaded = true;
            }
        }
    }
}
