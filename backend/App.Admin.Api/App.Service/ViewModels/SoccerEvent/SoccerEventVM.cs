using App.Service.ViewModels.SoccerEvent;
using App.Service.ViewModels.SoccerTeam;
using System;

namespace App.Service.ViewModels
{
    public class SoccerEventVM
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public SoccerTeamEventVM Home { get; set; }
        public int HomeTeamId { get; set; }
        public SoccerTeamEventVM Out { get; set; }
        public int OutTeamId { get; set; }
        public string Referee { get; set; }
        public string Venue { get; set; }
    }
}
