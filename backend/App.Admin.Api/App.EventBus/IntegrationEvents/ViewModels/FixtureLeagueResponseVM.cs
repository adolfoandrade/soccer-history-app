using Newtonsoft.Json;

namespace App.ViewModels
{
    public class FixtureLeagueResponseVM
    {
        [JsonProperty("fixture")]
        public FixtureVM Fixture { get; set; }

        [JsonProperty("league")]
        public FixtureLeagueVM League { get; set; }

        [JsonProperty("teams")]
        public FixtureTeamsVM Teams { get; set; }

        [JsonProperty("goals")]
        public FixtureGoalsVM Goals { get; set; }

        [JsonProperty("score")]
        public FixtureScoreVM Score { get; set; }
    }
}
