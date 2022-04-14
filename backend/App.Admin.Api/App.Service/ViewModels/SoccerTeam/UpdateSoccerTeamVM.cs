using System;

namespace App.Service.ViewModels.SoccerTeam
{
    public class UpdateSoccerTeamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
