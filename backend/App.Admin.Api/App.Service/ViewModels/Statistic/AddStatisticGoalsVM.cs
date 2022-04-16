namespace App.Service.ViewModels.Statistic
{
    public class AddStatisticGoalsVM
    {
        public EventTimeStatisticVM EventTimeStatistic { get; set; }
        public int Minute { get; set; }
        public string Player { get; set; }
        public string Assist { get; set; }
        public int EventTimeStatisticId { get; set; }
    }
}
