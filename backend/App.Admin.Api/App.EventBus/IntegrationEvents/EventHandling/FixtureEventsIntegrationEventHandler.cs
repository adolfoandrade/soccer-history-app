using App.EventBus.IntegrationEvents.Services;
using App.ViewModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class FixtureEventsIntegrationEventHandler : IIntegrationEventHandler<FixtureEventsIntegrationEvent>
    {
        private readonly IFixtureEventsIntegrationEventService _service;

        public FixtureEventsIntegrationEventHandler(IFixtureEventsIntegrationEventService service)
        {
            _service = service;
        }

        public async Task Handle(FixtureEventsIntegrationEvent @event)
        {
            var fixture_events = JsonConvert.DeserializeObject<ResponseVM<FixtureEventsResponseVM>>(@event.TheEvents);
            try
            {
                await _service.AddOrUpdateAsync(fixture_events.Response, @event.Fixture);
            }
            catch (Exception)
            {

            }
        }
    }
}
