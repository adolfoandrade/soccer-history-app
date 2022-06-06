using Newtonsoft.Json;
using System;

namespace SyncSoccerData.ViewModels
{
    public class FixtureScoreHalfTimeVM
    {
        [JsonProperty("home")]
        public Nullable<int> Home { get; set; }

        [JsonProperty("away")]
        public Nullable<int> Away { get; set; }
    }
}
