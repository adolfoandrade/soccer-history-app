namespace App.EventBus.IntegrationEvents.EventHandling
{
    public class UpdateCompetitionStatisticIntegrationEvent : IntegrationEvent
    {
        public int CompetitionId { get; set; }
    }
}
