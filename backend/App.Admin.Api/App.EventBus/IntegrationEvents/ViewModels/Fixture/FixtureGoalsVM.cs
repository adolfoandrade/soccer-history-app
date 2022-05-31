using Newtonsoft.Json;
using System;

namespace App.ViewModels
{
    public class FixtureGoalsVM
    {
        [JsonProperty("home")]
        public Nullable<int> Home { get; set; }

        [JsonProperty("away")]
        public Nullable<int> Away { get; set; }
    }
}
