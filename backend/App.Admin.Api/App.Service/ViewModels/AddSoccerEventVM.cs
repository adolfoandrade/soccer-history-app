using System;

namespace App.Service.ViewModels
{
    public class AddSoccerEventVM
    {
        public int MatchId { get; set; }
        public MatchVM Match { get; set; }
        public DateTime Date { get; set; }
        public int HomeTeamId { get; set; }
        public int OutTeamId { get; set; }
        public string Referee { get; set; }
        public string Venue { get; set; }
    }
}
