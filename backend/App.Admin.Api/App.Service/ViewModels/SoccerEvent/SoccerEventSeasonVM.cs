using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.ViewModels
{
    public class SoccerEventSeasonVM
    {
        public CompetitionVM Season { get; set; }
        public List<SoccerEventMatchVM> Matches { get; set; }
    }
}
