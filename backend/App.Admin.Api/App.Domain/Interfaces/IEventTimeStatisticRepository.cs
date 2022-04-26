using App.Domain.Models;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IEventTimeStatisticRepository
    {
        Task<int> AddAsync(EventTimeStatistic entity);
        Task<EventTimeStatistic> GetAsync(int eventId, int half, int soccerTeamId);
    }
}
