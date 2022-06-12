namespace SyncSoccerData.EventBus.IntegrationEvents.EventHandling
{
    public class FixtureStatisticsIntegrationEvent : IntegrationEvent
    {
        public string Statistics { get; set; }
        public long Fixture { get; set; }
    }
}
