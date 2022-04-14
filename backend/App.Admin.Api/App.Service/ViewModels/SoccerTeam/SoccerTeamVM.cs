using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.ViewModels.SoccerTeam
{
    public class SoccerTeamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
