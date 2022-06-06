using Newtonsoft.Json;
using System.Collections.Generic;

namespace SyncSoccerData.ViewModels
{
    public class ResponseVM<T>
    {
        [JsonProperty("get")]
        public string Get { get; set; }

        //[JsonProperty("parameters")]
        //public string[] Parameters { get; set; }

        //[JsonProperty("errors")]
        //public string[] Errors { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("paging")]
        public object Paging { get; set; }

        [JsonProperty("response")]
        public List<T> Response { get; set; }
    }
}
