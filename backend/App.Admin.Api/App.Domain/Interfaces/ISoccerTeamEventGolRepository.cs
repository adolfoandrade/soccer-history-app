using App.Domain.Models;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ISoccerTeamEventGolRepository
    {
        Task<int> AddAsync(SoccerTeamEventGol entity);
        Task<int> UpdateAsync(SoccerTeamEventGol entity);
        Task<int> DeleteAsync(int id);
    }
}
