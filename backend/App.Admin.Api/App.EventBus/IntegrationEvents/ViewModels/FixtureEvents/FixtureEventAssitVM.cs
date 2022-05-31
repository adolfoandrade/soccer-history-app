using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class FixtureEventAssitVM
    {
        [JsonProperty("id")]
        public Nullable<int> Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
