using System.Collections.Generic;
using Newtonsoft.Json;

namespace Library.Models
{
    public class RootObject
    {

        [JsonProperty("results")]
        public List<User> Users { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
