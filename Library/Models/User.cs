using Library.Enums;
using Newtonsoft.Json;

namespace Library.Models
{
    public class User
    {
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("login")]
        public Login Login { get; set; }

        [JsonProperty("dob")]
        public DOB BirthDate { get; set; }

        [JsonProperty("registered")]
        public Registered RegisteredDate { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("id")]
        public ID ID { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        [JsonProperty("nat")]
        public Nationality Nationality { get; set; }
    }
}
