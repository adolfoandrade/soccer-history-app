using App.Models;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ISoccerTeamRepository
    {
        Task<SoccerTeam> GetAsync(int id);
        Task<int> AddAsync(SoccerTeam competition);
        Task<int> UpdateAsync(SoccerTeam competition);
        Task<int> DeleteAsync(int id);
    }
}
