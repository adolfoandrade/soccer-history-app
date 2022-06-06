using Newtonsoft.Json;

namespace SyncSoccerData.ViewModels
{
    public class FixtureScoreVM
    {
        [JsonProperty("halftime")]
        public FixtureScoreHalfTimeVM Halftime { get; set; }

        [JsonProperty("fulltime")]
        public FixtureScoreFullTimeVM Fulltime { get; set; }

        [JsonProperty("extratime")]
        public FixtureScoreExtratimeVM Extratime { get; set; }

        [JsonProperty("penalty")]
        public FixtureScorePenaltyVM Penalty { get; set; }
    }
}
