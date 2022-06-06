using Newtonsoft.Json;
using System;

namespace SyncSoccerData.ViewModels
{
    public class FixtureEventTeamVM
    {
        [JsonProperty("id")]
        public Nullable<int> Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
