using Newtonsoft.Json;
using System.Collections.Generic;

namespace SyncSoccerData.ViewModels
{
    public class LeaguesResponseVM
    {
        [JsonProperty("league")]
        public LeagueVM LeagueVM { get; set; }

        [JsonProperty("country")]
        public LeagueVM CountryVM { get; set; }

        [JsonProperty("seasons")]
        public List<SeasonVM> Seasons { get; set; }
    }
}
