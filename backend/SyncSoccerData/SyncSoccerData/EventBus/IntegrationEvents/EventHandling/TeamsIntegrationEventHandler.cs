using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.EventBus.IntegrationEvents.EventHandling
{
    public class TeamsIntegrationEventHandler : IIntegrationEventHandler<TeamsIntegrationEvent>
    {
        public Task Handle(TeamsIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
