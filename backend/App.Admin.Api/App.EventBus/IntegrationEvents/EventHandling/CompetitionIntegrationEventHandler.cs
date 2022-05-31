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
    public class CompetitionIntegrationEventHandler : App.EventBus.IIntegrationEventHandler<CompetitionIntegrationEvent>
    {
        private readonly ICompetitionIntegrationEventService _service;

        public CompetitionIntegrationEventHandler(ICompetitionIntegrationEventService service)
        {
            _service = service;
        }

        public async Task Handle(CompetitionIntegrationEvent @event)
        {
            try
            {
                var competitions = JsonConvert.DeserializeObject<ResponseVM<LeaguesResponseVM>>(@event.Competitions);
                await _service.AddAsync(competitions.Response);
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
