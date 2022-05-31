using Newtonsoft.Json;

namespace App.ViewModels
{
    public class FixtureTeamsVM
    {
        [JsonProperty("home")]
        public FixtureHomeTeamVM Home { get; set; }

        [JsonProperty("away")]
        public FixtureAwayTeamVM Away { get; set; }
    }
}
