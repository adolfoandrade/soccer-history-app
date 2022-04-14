using App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ISoccerTeamRepository
    {
        Task<IEnumerable<SoccerTeam>> FilterAsync(string filter);
        Task<IEnumerable<SoccerTeam>> GetAsync();
        Task<SoccerTeam> GetAsync(int id);
        Task<int> AddAsync(SoccerTeam soccerTeam);
        Task<int> UpdateAsync(SoccerTeam soccerTeam);
        Task<int> DeleteAsync(int id);
    }
}
