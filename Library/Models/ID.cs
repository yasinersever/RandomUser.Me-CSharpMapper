using Newtonsoft.Json;

namespace Library.Models
{
    public class ID
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
