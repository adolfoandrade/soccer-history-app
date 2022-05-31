using Newtonsoft.Json;
using System;

namespace App.ViewModels
{
    public class FixtureStatusVM
    {
        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }

        [JsonProperty("elapsed")]
        public Nullable<int> Elapsed { get; set; }
    }
}
