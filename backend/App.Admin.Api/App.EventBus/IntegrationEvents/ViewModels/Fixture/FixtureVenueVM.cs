using Newtonsoft.Json;

namespace App.ViewModels
{
    public class FixtureVenueVM
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
