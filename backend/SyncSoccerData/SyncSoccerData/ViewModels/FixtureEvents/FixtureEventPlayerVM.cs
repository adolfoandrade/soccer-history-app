using Newtonsoft.Json;
using System;

namespace SyncSoccerData.ViewModels
{
    public class FixtureEventPlayerVM
    {
        [JsonProperty("id")]
        public Nullable<int> Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
