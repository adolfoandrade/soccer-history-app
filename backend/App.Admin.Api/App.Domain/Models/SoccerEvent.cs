using System;

namespace App.Models
{
    public class SoccerEvent
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public DateTime Date { get; set; }
        public SoccerTeam Home { get; set; }
        public int HomeTeamId { get; set; }
        public SoccerTeam Out { get; set; }
        public int OutTeamId { get; set; }
        public string Referee { get; set; }
        public string Venue { get; set; }
    }
}
