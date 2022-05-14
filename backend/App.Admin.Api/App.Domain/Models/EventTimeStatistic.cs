using App.Domain.Models.Enum;
using App.Models;

namespace App.Domain.Models
{
    public class EventTimeStatistic
    {
        public int Id { get; set; }
        public SoccerTimers Half { get; set; }
        public int EventId { get; set; }
        public SoccerEvent SoccerEvent { get; set; }
        public int SoccerTeamId { get; set; }
        public SoccerTeam SoccerTeam { get; set; }
        public SoccerTeamEventGol Goal { get; set; }
        public SoccerTeamEventCard Card { get; set; }
        public Statistic Statistic { get; set; }
    }
}
