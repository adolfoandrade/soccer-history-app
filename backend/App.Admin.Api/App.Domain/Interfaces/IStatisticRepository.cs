using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IStatisticRepository
    {
        Task<Tuple<Statistic, Statistic>> GetByMatchAsync(int eventId);
        Task<IEnumerable<Statistic>> GetByCompetitionAsync(int competitionId);
        Task<int> AddAsync(Statistic entity);
        Task<Statistic> HasAsync(int eventId, int teamId, string period);
        Task<int> UpdateAsync(Statistic entity);
        Task<int> DeleteAsync(int id);
    }
}
