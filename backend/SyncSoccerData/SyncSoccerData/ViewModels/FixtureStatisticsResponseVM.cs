using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.ViewModels
{
    public class FixtureStatisticsResponseVM
    {
        [JsonProperty("team")]
        public FixtureStatisticTeamVM Team { get; set; }

        [JsonProperty("statistics")]
        public List<FixtureStatisticVM> Statistics { get; set; }
    }
}
