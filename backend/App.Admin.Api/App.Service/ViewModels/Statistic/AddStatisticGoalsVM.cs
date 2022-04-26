namespace App.Service.ViewModels.Statistic
{
    public class AddStatisticGoalsVM
    {
        public string Half { get; set; }
        public int EventId { get; set; }
        public int SoccerTeamId { get; set; }
        public int Minute { get; set; }
        public string Player { get; set; }
        public string Assist { get; set; }
        public int EventTimeStatisticId { get; set; }
    }
}
