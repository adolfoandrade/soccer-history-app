using System.Collections.Generic;

namespace App.Service.ViewModels
{
    public class SoccerEventMatchVM
    {
        public MatchVM Match { get; set; }
        public List<SoccerEventVM> Events { get; set; }
    }
}
