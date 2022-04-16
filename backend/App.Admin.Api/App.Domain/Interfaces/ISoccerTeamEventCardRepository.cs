using App.Domain.Models;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ISoccerTeamEventCardRepository
    {
        Task<SoccerTeamEventCard> GetAsync(int id);
        Task<int> AddAsync(SoccerTeamEventCard entity);
        Task<int> UpdateAsync(SoccerTeamEventCard entity);
        Task<int> DeleteAsync(int id);
    }
}
