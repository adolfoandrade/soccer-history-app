using App.Models;

namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class CompetitionStatisticIntegrationEvent : IntegrationEvent
    {
        public Competition Competition { get; set; }
        public StatisticAvg Offsides { get; set; }
        public StatisticAvg Cards { get; set; }
        public StatisticAvg Goals { get; set; }
        public StatisticAvg CornerKicks { get; set; }
        public StatisticAvg Raws { get; set; }
    }

    public class StatisticAvg
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Avg { get; set; }
    }
}
