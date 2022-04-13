using App.Models;
using App.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface ICompetitionService
    {
        Task<IEnumerable<CompetitionVM>> GetBySeasonAsync(string season);
        Task<CompetitionVM> AddAsync(CompetitionVM vm);
        Task<bool> UpdateAsync(CompetitionVM vm);
        Task<bool> DeleteAsync(int id);
    }
}
