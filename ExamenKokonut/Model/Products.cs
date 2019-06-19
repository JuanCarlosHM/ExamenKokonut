namespace ExamenKokonut.Model
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;


    public class Products
    {
        [JsonProperty("success")]
        public long Success { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("data")]
        public Data DataLog { get; set; }


        public partial class Data
        {
            [JsonProperty("current_page")]
            public long CurrentPage { get; set; }

            [JsonProperty("data")]
            public List<Datum> DataData { get; set; }

            [JsonProperty("first_page_url")]
            public Uri FirstPageUrl { get; set; }

            [JsonProperty("from")]
            public long From { get; set; }

            [JsonProperty("last_page")]
            public long LastPage { get; set; }

            [JsonProperty("last_page_url")]
            public Uri LastPageUrl { get; set; }

            [JsonProperty("next_page_url")]
            public object NextPageUrl { get; set; }

            [JsonProperty("path")]
            public Uri Path { get; set; }

            [JsonProperty("per_page")]
            public long PerPage { get; set; }

            [JsonProperty("prev_page_url")]
            public object PrevPageUrl { get; set; }

            [JsonProperty("to")]
            public long To { get; set; }

            [JsonProperty("total")]
            public long Total { get; set; }
        }

        public partial class Datum
        {
            [JsonProperty("id_post")]
            public int IdPost { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("header")]
            public string Header { get; set; }

            [JsonProperty("footer")]
            public string Footer { get; set; }

            [JsonProperty("image_url")]
            public Uri ImageUrl { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }
        }

       
    } // end Class 
}
