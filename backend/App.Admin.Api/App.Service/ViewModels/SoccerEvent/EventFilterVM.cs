namespace App.Service.ViewModels.SoccerEvent
{
    public class EventFilterVM
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int CompetitionId { get; set; }
        public string Search { get; set; }
    }
}
