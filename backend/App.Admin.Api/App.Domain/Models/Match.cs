namespace App.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Letter { get; set; }
        public string Stage { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
