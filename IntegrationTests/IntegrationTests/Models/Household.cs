namespace IntegrationTests.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Household
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        public static Household FromJson(string json) => JsonConvert.DeserializeObject<Household>(json, Converter.Settings);
    }
}
