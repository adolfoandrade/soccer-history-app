using App.Service.ViewModels.SoccerEvent;
using App.Service.ViewModels.SoccerTeam;

namespace App.Service.ViewModels.Statistic
{
    public class EventTimeStatisticVM
    {
        public int Id { get; set; }
        public string Half { get; set; }
        public int EventId { get; set; }
        public SoccerEventVM SoccerEvent { get; set; }
        public int SoccerTeamId { get; set; }
        public SoccerTeamVM SoccerTeam { get; set; }
        public SoccerTeamEventGolVM Goal { get; set; }
        public SoccerTeamEventCardVM Card { get; set; }
        public StatisticVM Statistic { get; set; }
    }
}
