using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public interface IStatistcsToBotIntegrationEventService
    {
        Task Send(int id);
    }
}
