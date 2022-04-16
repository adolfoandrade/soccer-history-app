namespace App.Service.ViewModels.Statistic
{
    public class AddStatisticCardsVM
    {
        public EventTimeStatisticVM EventTimeStatistic { get; set; }
        public int Minute { get; set; }
        public string Player { get; set; }
        public string Color { get; set; }
        public int EventTimeStatisticId { get; set; }
    }
}
