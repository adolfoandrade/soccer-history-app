namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class ExecuteStatistcsToBotIntegrationEvent : IntegrationEvent
    {
        public int CompetitionId { get; set; }
    }
}
