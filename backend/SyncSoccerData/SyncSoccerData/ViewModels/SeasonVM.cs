using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.ViewModels
{
    public class SeasonVM
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        [JsonProperty("current")]
        public bool Current { get; set; }

        [JsonProperty("coverage")]
        public CoverageVM Coverage { get; set; }
    }
}
