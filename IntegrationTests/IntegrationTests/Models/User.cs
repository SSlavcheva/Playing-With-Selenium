namespace IntegrationTests.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("householdId")]
        public long HouseholdId { get; set; }

        [JsonProperty("wishlistId")]
        public long WishlistId { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        public static User UserFromJson(string json) => JsonConvert.DeserializeObject<User>(json, Converter.Settings);

        public static List<User> ListFromJson(string json) => JsonConvert.DeserializeObject<List<User>>(json, IntegrationTests.Models.Converter.Settings);
    }
}
