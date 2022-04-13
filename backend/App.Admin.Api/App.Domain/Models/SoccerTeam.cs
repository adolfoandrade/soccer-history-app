using System;

namespace App.Models
{
    public class SoccerTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
