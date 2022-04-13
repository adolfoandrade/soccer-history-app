using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.ViewModels
{
    public class SoccerEventMatchVM
    {
        public MatchVM Match { get; set; }
        public List<SoccerEventVM> Events { get; set; }
    }
}
