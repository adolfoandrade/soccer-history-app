using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class TeamsIntegrationEvent : IntegrationEvent
    {
        public string Teams { get; set; }
    }
}
