using System;
using Newtonsoft.Json;

namespace Library.Models
{
    public class DOB
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
