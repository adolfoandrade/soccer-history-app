using System.Collections.Generic;

namespace App.Service.ViewModels
{
    public class SoccerEventSeasonVM
    {
        public CompetitionVM Season { get; set; }
        public List<SoccerEventMatchVM> Matches { get; set; }
    }
}
