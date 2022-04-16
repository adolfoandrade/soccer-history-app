﻿namespace App.Domain.Models
{
    public class SoccerTeamEventCard
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public string Player { get; set; }
        public string Color { get; set; }
        public int EventTimeStatisticId { get; set; }
        public EventTimeStatistic EventTimeStatistic { get; set; }
    }
}
