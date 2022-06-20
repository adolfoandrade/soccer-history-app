using App.Models;
using System.Collections.Generic;

namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class CompetitionStatisticIntegrationEvent : IntegrationEvent
    {
        public string Statistics { get; set; }
    }

    public class StatisticAvgDataByMatch
    {
        public int Round { get; set; }
        public Competition Competition { get; set; }
        public StatisticAvgData StatisticAvgData { get; set; }
    }

    public class StatisticAvgData
    {
        public Competition Competition { get; set; }
        public StatisticAvg Offsides { get; set; }
        public StatisticAvg Cards { get; set; }
        public StatisticAvg Goals { get; set; }
        public StatisticAvg CornerKicks { get; set; }
        public StatisticAvg Draws { get; set; }
    }

    public class StatisticAvg
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Avg { get; set; }
    }
}
