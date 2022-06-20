using App.EventBus.IntegrationEvents.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class UpdateCompetitionStatisticIntegrationEventHandler : IIntegrationEventHandler<UpdateCompetitionStatisticIntegrationEvent>
    {
        private readonly IStatistcsToBotIntegrationEventService _service;

        public UpdateCompetitionStatisticIntegrationEventHandler(IStatistcsToBotIntegrationEventService service)
        {
            _service = service;
        }

        public async Task Handle(UpdateCompetitionStatisticIntegrationEvent @event)
        {
            try
            {
                await _service.Send(@event.CompetitionId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
