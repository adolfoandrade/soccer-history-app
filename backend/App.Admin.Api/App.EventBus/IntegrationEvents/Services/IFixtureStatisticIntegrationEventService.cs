using App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.EventBus.IntegrationEvents.Services
{
    public interface IFixtureStatisticIntegrationEventService
    {
        Task<bool> AddOrUpdateAsync(List<FixtureStatisticsResponseVM> vm, long id);
    }
}
