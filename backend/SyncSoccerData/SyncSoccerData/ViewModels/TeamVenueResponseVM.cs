using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.ViewModels
{
    public class TeamVenueResponseVM
    {
        [JsonProperty("team")]
        public TeamVM Team { get; set; }

        [JsonProperty("venue")]
        public VenueVM Venue { get; set; }
    }
}
