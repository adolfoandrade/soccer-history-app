using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.ViewModels
{
    public class FixtureVM
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("referee")]
        public string Referee { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("periods")]
        public FixturePeriodVM Periods { get; set; }

        [JsonProperty("venue")]
        public FixtureVenueVM Venue { get; set; }

        [JsonProperty("status")]
        public FixtureStatusVM Status { get; set; }
    }
}
