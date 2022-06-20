using App.Domain.Models;
using App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IStatisticRepository
    {
        Task<Tuple<Statistic, Statistic>> GetByMatchAsync(int eventId);
        Task<IEnumerable<Statistic>> GetByCompetitionAsync(int competitionId);
        Task<IEnumerable<MatchEvent>> GetGoalsByMatchAsync(params int[] competitionId);
        Task<IEnumerable<Match>> GetMatchesByCompetitionAsync(int competitionId);
        Task<IEnumerable<MatchEvent>> GetGoalsByCompetitionsAsync(params int[] competitionId);
        Task<IEnumerable<MatchEvent>> GetCardsByMatchAsync(params int[] competitionId);
        Task<int> AddAsync(Statistic entity);
        Task<int> SaveDataOddAsync(IEnumerable<StatisticOddByMatch> entity);
        Task<Statistic> HasAsync(int eventId, int teamId, string period);
        Task<int> UpdateAsync(Statistic entity);
        Task<int> DeleteAsync(int id);
    }
}
