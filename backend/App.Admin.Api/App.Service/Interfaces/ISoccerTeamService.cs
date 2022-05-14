using App.Service.ViewModels.SoccerTeam;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface ISoccerTeamService
    {
        Task<IEnumerable<SoccerTeamVM>> FilterAsync(string filter);
        Task<IEnumerable<SoccerTeamVM>> GetAsync();
        Task<SoccerTeamVM> GetAsync(int id);
        Task<int> AddAsync(AddSoccerTeamVM vm);
        Task<bool> UpdateAsync(UpdateSoccerTeamVM vm);
        Task<bool> DeleteAsync(int id);
    }
}
