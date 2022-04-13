using App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ISoccerEventRepository
    {
        Task<IEnumerable<SoccerEvent>> GetBySeasonAsync(int seasonId);
        Task<IEnumerable<SoccerEvent>> GetByMatchAsync(string match);
        Task<SoccerEvent> GetAsync(int id);
        Task<int> AddAsync(SoccerEvent soccerEvent);
        Task<int> UpdateAsync(SoccerEvent soccerEvent);
        Task<int> DeleteAsync(int id);
    }
}
