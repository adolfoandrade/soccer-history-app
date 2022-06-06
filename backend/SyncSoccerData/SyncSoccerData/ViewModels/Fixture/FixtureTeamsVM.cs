using Newtonsoft.Json;

namespace SyncSoccerData.ViewModels
{
    public class FixtureTeamsVM
    {
        [JsonProperty("home")]
        public FixtureHomeTeamVM Home { get; set; }

        [JsonProperty("away")]
        public FixtureAwayTeamVM Away { get; set; }
    }
}
