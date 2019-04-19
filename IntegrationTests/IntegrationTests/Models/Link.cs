namespace IntegrationTests.Models
{
    using Newtonsoft.Json;
    using System;

    public partial class Link
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }

        public static Link FromJson(string json) => JsonConvert.DeserializeObject<Link>(json, Converter.Settings);
    }
}
