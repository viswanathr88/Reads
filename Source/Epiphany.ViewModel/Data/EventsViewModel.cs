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
    /// <summary>
    /// Class that implements <see cref="IEventsViewModel"/>
    /// </summary>
    public sealed class EventsViewModel : DataViewModel<VoidType>, IEventsViewModel
    {
        private readonly IEventService eventService;
        private readonly IDeviceServices deviceServices;

        private IEventItemViewModel selectedEvent;
        private IList<IEventItemViewModel> events;
        private readonly IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> fetchEventsCommand;
        /// <summary>
        /// Create a new instance of <see cref="EventsViewModel"/>
        /// </summary>
        /// <param name="eventService">Event Service</param>
        /// <param name="deviceServices">Device Services</param>
        public EventsViewModel(IEventService eventService, IDeviceServices deviceServices)
        {
            this.eventService = eventService;
            this.deviceServices = deviceServices;

            this.fetchEventsCommand = new FetchEventsCommand(eventService, deviceServices);
            RegisterCommand(this.fetchEventsCommand, OnCommandExecuted);
        }
        /// <summary>
        /// Gets the list of literary events
        /// </summary>
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
        /// <summary>
        /// Gets or sets the selected event
        /// </summary>
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
        /// <summary>
        /// Command to start fetching literary events
        /// </summary>
        public IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents
        {
            get { return this.fetchEventsCommand; }
        }
        /// <summary>
        /// Command to refresh literary events
        /// </summary>
        public ICommand Refresh
        {
            get { return this.fetchEventsCommand; }
        }
        /// <summary>
        /// Load the ViewModel async
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task LoadAsync(VoidType parameter)
        {
            if (this.fetchEventsCommand.CanExecute(parameter))
            {
                await this.fetchEventsCommand.ExecuteAsync(parameter);
            }
        }
        /// <summary>
        /// Override method when command is executing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            base.OnCommandExecuting(sender, e);

            Events = new ObservableCollection<IEventItemViewModel>();
        }
        /// <summary>
        /// Callback when command has finished execution
        /// </summary>
        /// <param name="e"></param>
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
