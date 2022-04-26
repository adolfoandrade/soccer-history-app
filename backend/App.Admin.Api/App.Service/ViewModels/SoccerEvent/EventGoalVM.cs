using App.Domain.Models;
using App.Service.ViewModels.SoccerTeam;

namespace App.Service.ViewModels.SoccerEvent
{
    public class EventGoalVM
    {
        public int Id { get; set; }
        public string Half { get; set; }
        public SoccerTeamVM SoccerTeam { get; set; }
        public SoccerTeamEventGolVM Goal { get; set; }
    }
}
