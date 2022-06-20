using App.Domain.Models.Enum;

namespace App.Domain.Models
{
    public class StatisticOddByMatch
    {
        public int CompetitionId { get; set; }
        public int QuantityEvents { get; set; }
        public Odd Odd { get; set; }
        public int MatchNumber { get; set; }
        public double? OverUnder { get; set; }
        public int Quantity { get; set; }
    }
}
