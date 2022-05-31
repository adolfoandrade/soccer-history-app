using Newtonsoft.Json;

namespace App.ViewModels
{
    public class FixturePeriodVM
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("second")]
        public string Second { get; set; }
    }
}
