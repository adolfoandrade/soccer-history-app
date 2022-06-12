using App.Domain.Exceptions.ApiValueReference;
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
    public class FixtureIntegrationEventHandler : IIntegrationEventHandler<FixtureIntegrationEvent>
    {
        private readonly IFixtureIntegrationEventService _service;

        public FixtureIntegrationEventHandler(IFixtureIntegrationEventService service)
        {
            _service = service;
        }

        public async Task Handle(FixtureIntegrationEvent @event)
        {
            try
            {
                var teams = JsonConvert.DeserializeObject<ResponseVM<FixtureLeagueResponseVM>>(@event.Fixtures);
                await _service.AddOrUpdateAsync(teams.Response);
            }
            catch (QueryApiValueReferenceException ex)
            {
                throw;
            }
            catch (AddApiValueReferenceException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
