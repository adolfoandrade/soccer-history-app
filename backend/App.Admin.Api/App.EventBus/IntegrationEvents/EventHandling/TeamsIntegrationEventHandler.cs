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
    public class TeamsIntegrationEventHandler : IIntegrationEventHandler<TeamsIntegrationEvent>
    {
        private readonly ITeamsIntegrationEventService _service;

        public TeamsIntegrationEventHandler(ITeamsIntegrationEventService service)
        {
            _service = service;
        }

        public async Task Handle(TeamsIntegrationEvent @event)
        {
            try
            {
                var teams = JsonConvert.DeserializeObject<ResponseVM<TeamVenueResponseVM>>(@event.Teams);
                await _service.AddAsync(teams.Response);
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
