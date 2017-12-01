using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
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

        private ILazyObservableCollection<IEventItemViewModel> events;
        private RelayCommand refreshCommand;
        /// <summary>
        /// Create a new instance of <see cref="EventsViewModel"/>
        /// </summary>
        /// <param name="eventService">Event Service</param>
        /// <param name="deviceServices">Device Services</param>
        public EventsViewModel(IEventService eventService, IDeviceServices deviceServices)
        {
            this.eventService = eventService;
            this.deviceServices = deviceServices;
            this.refreshCommand = new RelayCommand(
                () => CreateCollection(), () => !IsLoading);
        }
        /// <summary>
        /// Gets the list of literary events
        /// </summary>
        public ILazyObservableCollection<IEventItemViewModel> Events
        {
            get
            {
                return this.events;
            }
            private set
            {
                SetProperty(ref this.events, value);
            }
        }
        /// <summary>
        /// Command to refresh literary events
        /// </summary>
        public ICommand Refresh
        {
            get { return this.refreshCommand; }
        }

        /// <summary>
        /// Load the ViewModel async
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override Task LoadAsync(VoidType parameter)
        {
            CreateCollection();
            return Task.FromResult(0);
        }

        private void CreateCollection()
        {
            if (Events != null)
            {
                Events.PropertyChanged -= Events_PropertyChanged;
            }

            Events = new LazyObservableCollection<IEventItemViewModel, LiteraryEventModel>(
                async() =>
                {
                    var coords = await this.deviceServices.GetCoordinatesAsync();
                    return await this.eventService.GetEvents(coords.Latitude, coords.Longitude);
                },
                (model) => new EventItemViewModel(model));
            Events.PropertyChanged += Events_PropertyChanged;
        }

        private void Events_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Events.IsLoading))
            {
                IsLoading = Events.IsLoading;
                if (!Events.IsLoading)
                {
                    IsLoaded = (Events.Count != 0 || Error != null);
                }

                this.refreshCommand.NotifyCanExecuteChanged();

            }
            else if (e.PropertyName == nameof(Events.Error))
            {
                Error = Events.Error;
                IsLoaded = false;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (Events != null)
            {
                Events.PropertyChanged -= Events_PropertyChanged;
            }
        }
    }
}
