using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.EventBus.IntegrationEvents.EventHandling
{
    public class CompetitionIntegrationEventHandler : IIntegrationEventHandler<CompetitionIntegrationEvent>
    {

        public Task Handle(CompetitionIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
