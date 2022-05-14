namespace App.Domain.Models
{
    public class SoccerTeamEventGol
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public string Player { get; set; }
        public string Assist { get; set; }
        public int EventTimeStatisticId { get; set; }
        public EventTimeStatistic EventTimeStatistic { get; set; }
    }
}
