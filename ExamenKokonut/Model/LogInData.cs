namespace ExamenKokonut.Model
{
    using Newtonsoft.Json;

    public class LogInData
    {
        [JsonProperty(PropertyName = "success")]
        public int Success { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Data DataLog { get; set; }

        public class Data
        {
            [JsonProperty(PropertyName = "token_type")]
            public string TokenType { get; set; }

            [JsonProperty(PropertyName = "expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }

            [JsonProperty(PropertyName = "refresh_token")]
            public string RefreshToken { get; set; }
        }


    }// End Class
}
