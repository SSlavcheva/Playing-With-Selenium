namespace IntegrationTests.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class Book
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publicationDate")]
        public DateTimeOffset? PublicationDate { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }

        public static List<Book> ListFromJson(string json) => JsonConvert.DeserializeObject<List<Book>>(json, Converter.Settings);

        public static Book UserFromJson(string json) => JsonConvert.DeserializeObject<Book>(json, Converter.Settings);

    }
}
