namespace SyncSoccerData.EventBus.IntegrationEvents.EventHandling
{
    public class UpdateCompetitionStatisticIntegrationEvent : IntegrationEvent
    {
        public int CompetitionId { get; set; }
    }
}
