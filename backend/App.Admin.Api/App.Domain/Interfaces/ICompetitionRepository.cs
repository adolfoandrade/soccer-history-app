using App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<IEnumerable<Competition>> GetBySeasonAsync(string season);
        Task<Competition> AddAsync(Competition competition);
        Task<int> UpdateAsync(Competition competition);
        Task<int> DeleteAsync(int id);
    }
}
