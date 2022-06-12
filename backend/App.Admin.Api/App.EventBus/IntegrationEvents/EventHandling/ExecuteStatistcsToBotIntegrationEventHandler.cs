using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class ExecuteStatistcsToBotIntegrationEventHandler : IIntegrationEventHandler<ExecuteStatistcsToBotIntegrationEvent>
    {
        public Task Handle(ExecuteStatistcsToBotIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
