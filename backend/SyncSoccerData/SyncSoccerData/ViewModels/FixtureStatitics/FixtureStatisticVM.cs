using Newtonsoft.Json;

namespace SyncSoccerData.ViewModels
{
    public class FixtureStatisticVM
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
