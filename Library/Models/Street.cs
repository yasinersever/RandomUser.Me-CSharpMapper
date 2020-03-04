using Newtonsoft.Json;

namespace Library.Models
{
    public class Street
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
