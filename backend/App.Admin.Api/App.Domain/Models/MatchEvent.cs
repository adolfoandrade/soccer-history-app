﻿using App.Models;

namespace App.Domain.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public SoccerTeam Team { get; set; }
        public int TeamId { get; set; }
        public SoccerEvent TheEvent { get; set; }
        public int EventId { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string Detail { get; set; }
        public string Player { get; set; }
        public string Assist { get; set; }
        public int Elapsed { get; set; }
        public int Extra { get; set; }
    }
}
