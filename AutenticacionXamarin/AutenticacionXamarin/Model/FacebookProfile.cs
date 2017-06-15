using Newtonsoft.Json;

namespace AutenticacionXamarin.Model
{
    public class FacebookProfile
    {
        public string Name { get; set; }
        public Picture Picture { get; set; }
        public string Locale { get; set; }
        public string Link { get; set; }
        public Cover Cover { get; set; }

        [JsonProperty("age_range")]
        public AgeRange AgeRange { get; set; }

        public Device[] Devices { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Gender { get; set; }
        public bool IsVerified { get; set; }
        public string Id { get; set; }
    }
}
