using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class CountriesResponseVM
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
        public List<CountryVM> Response { get; set; }
    }
}
