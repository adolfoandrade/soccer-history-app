using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class FixtureStatisticsResponseVM
    {
        [JsonProperty("team")]
        public FixtureStatisticTeamVM Team { get; set; }

        [JsonProperty("statistics")]
        public List<FixtureStatisticVM> Statistics { get; set; }
    }
}
