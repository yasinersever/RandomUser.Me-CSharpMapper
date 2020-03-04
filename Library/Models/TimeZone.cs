using Newtonsoft.Json;

namespace Library.Models
{
    public class TimeZone
    {

        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("Description")]
        public string description { get; set; }
    }
}
