﻿using Newtonsoft.Json;
using System;

namespace App.ViewModels
{
    public class FixtureAwayTeamVM
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("winner")]
        public Nullable<bool> Winner { get; set; }
    }
}
