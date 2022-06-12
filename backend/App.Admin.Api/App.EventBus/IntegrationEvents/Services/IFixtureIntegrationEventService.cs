using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public interface IFixtureIntegrationEventService
    {
        Task<bool> AddOrUpdateAsync(List<FixtureLeagueResponseVM> vm);
    }
}
