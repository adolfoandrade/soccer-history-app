using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IMatchEventsRepository
    {
        Task<MatchEvent> HasAsync(int teamId, int eventId, string type, int elapsed, int extra);
        Task<IEnumerable<MatchEvent>> GetByCompetitionAsync(int competitionId);
        Task<int> AddAsync(MatchEvent matchEvent);
    }
}
