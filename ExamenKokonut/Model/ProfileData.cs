namespace ExamenKokonut.Model
{
    using System;
    using Newtonsoft.Json;

    public class ProfileData
    {

        [JsonProperty("success")]
        public long Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("data")]
        public Data DataLog { get; set; }
    }

    public class Data
    {
        [JsonProperty("id_user")]
        public string IdUser { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("created_at")]
        public DatedAt CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DatedAt UpdatedAt { get; set; }

    }
   
    public  class DatedAt
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("timezone_type")]
        public long TimezoneType { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
