namespace IntegrationTests
{
    using AutoFixture;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Net.Http;

    public class BaseTest
    {
        public HttpClient Client { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:3000");
            Client.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        public Fixture Fixture => new Fixture();

        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
