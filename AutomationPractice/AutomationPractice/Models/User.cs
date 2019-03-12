using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class User
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTimeOffset DateOfBirth { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("firstNameA")]
        public string FirstNameA { get; set; }

        [JsonProperty("lastNameA")]
        public string LastNameA { get; set; }

        [JsonProperty("Company")]
        public string Company { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("Info")]
        public string Info { get; set; }

        [JsonProperty("HomePhone")]
        public string HomePhone { get; set; }

        [JsonProperty("MobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("AddressAlias")]
        public string AddressAlias { get; set; }
    }

    public partial class User
    {
        public static User FromJson(string json) => JsonConvert.DeserializeObject<User>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this User self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}