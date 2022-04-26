using App.Service.ViewModels.SoccerTeam;

namespace App.Service.ViewModels.SoccerEvent
{
    public class EventCardVM
    {
        public int Id { get; set; }
        public string Half { get; set; }
        public SoccerTeamVM SoccerTeam { get; set; }
        public SoccerTeamEventCardVM Card { get; set; }
    }
}
