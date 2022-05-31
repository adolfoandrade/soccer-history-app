using Newtonsoft.Json;
using System;

namespace App.ViewModels
{
    public class FixtureEventTimeVM
    {
        [JsonProperty("elapsed")]
        public Nullable<int> Elapsed { get; set; }

        [JsonProperty("extra")]
        public Nullable<int> Extra { get; set; }
    }
}
