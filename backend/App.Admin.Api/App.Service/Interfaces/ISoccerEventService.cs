using App.Models;
using App.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface ISoccerEventService
    {
        Task<SoccerEventSeasonVM> GetBySeasonAsync(int competitionId, string season);
        Task<SoccerEventMatchVM> GetByMatchAsync(string match, int competitionId);
        Task<SoccerEventVM> GetAsync(int id);
        Task<int> AddAsync(AddSoccerEventVM soccerEvent);
        Task<bool> UpdateAsync(UpdateSoccerEventVM soccerEvent);
        Task<bool> DeleteAsync(int id);
    }
}
