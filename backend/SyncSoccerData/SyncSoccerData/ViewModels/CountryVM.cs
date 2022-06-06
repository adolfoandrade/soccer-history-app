using Newtonsoft.Json;

namespace SyncSoccerData.ViewModels
{
    public class CountryVM
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}
