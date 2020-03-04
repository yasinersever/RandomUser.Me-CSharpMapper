using Newtonsoft.Json;

namespace RandomUser.Me.Models
{
    public class ID
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }
}
