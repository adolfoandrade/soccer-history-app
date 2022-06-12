using App.EventBus.IntegrationEvents.Services;
using App.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class FixtureStatisticsIntegrationEventHandler : IIntegrationEventHandler<FixtureStatisticsIntegrationEvent>
    {
        private readonly IFixtureStatisticIntegrationEventService _service;

        public FixtureStatisticsIntegrationEventHandler(IFixtureStatisticIntegrationEventService service)
        {
            _service = service;
        }

        public async Task Handle(FixtureStatisticsIntegrationEvent @event)
        {
            var fixture_statistics = JsonConvert.DeserializeObject<ResponseVM<FixtureStatisticsResponseVM>>(@event.Statistics);
            try
            {
                await _service.AddOrUpdateAsync(fixture_statistics.Response, @event.Fixture);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
