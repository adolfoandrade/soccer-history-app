using App.Domain.Models;
using System;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IStatisticRepository
    {
        Task<Tuple<Statistic, Statistic>> GetByMatchAsync(int eventId);
        Task<int> AddAsync(Statistic entity);
        Task<int> UpdateAsync(Statistic entity);
        Task<int> DeleteAsync(int id);
    }
}
