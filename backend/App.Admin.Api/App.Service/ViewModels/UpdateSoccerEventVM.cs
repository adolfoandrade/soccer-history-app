﻿using App.Service.ViewModels.SoccerTeam;
using System;

namespace App.Service.ViewModels
{
    public class UpdateSoccerEventVM
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public MatchVM Match { get; set; }
        public DateTime Date { get; set; }
        public SoccerTeamVM Home { get; set; }
        public int HomeTeamId { get; set; }
        public SoccerTeamVM Out { get; set; }
        public int OutTeamId { get; set; }
        public string Referee { get; set; }
        public string Venue { get; set; }
    }
}
