using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class FetchEventsCommand : AsyncCommand<IEnumerable<LiteraryEventModel>, VoidType>
    {
        private readonly IEventService eventService;
        private readonly ILocationService locationService;

        public FetchEventsCommand(IEventService eventService, ILocationService locationService)
        {
            if (eventService == null || locationService == null)
            {
                throw new ArgumentNullException("services");
            }

            this.eventService = eventService;
            this.locationService = locationService;
        }
        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override async Task RunAsync(VoidType param)
        {
            GeoCoords coords = await this.locationService.GetCoordinatesAsync();
            Result = await this.eventService.GetEvents(coords.Latitude, coords.Longitude);
        }
    }
}
