using Newtonsoft.Json;

namespace RandomUser.Me.Models
{
    public class Picture
    {

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

    }
}
