namespace SyncSoccerData.EventBus.IntegrationEvents.EventHandling
{
    public class FixtureEventsIntegrationEvent : IntegrationEvent
    {
        public string TheEvents { get; set; }
        public long Fixture { get; set; }
    }
}
