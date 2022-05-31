using Newtonsoft.Json;

namespace App.ViewModels
{
    public class FixtureEventsResponseVM
    {
        [JsonProperty("time")]
        public FixtureEventTimeVM Time { get; set; }

        [JsonProperty("team")]
        public FixtureEventTeamVM Team { get; set; }

        [JsonProperty("player")]
        public FixtureEventPlayerVM Player { get; set; }

        [JsonProperty("assist")]
        public FixtureEventAssitVM Assist { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
