namespace IntegrationTests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class Tests : BaseTest
    {
        private const string host = "http://localhost:3000";

        private HttpClient client;
        private long? householdId = 1;
        private List<long> wishlistIds = new List<long>();
        private List<Book> listOfBooks = new List<Book>();
        private Random random = new Random();

        [SetUp]
        public void SetUp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        [Test]
        [Order(1)]
        public async Task CreateHouseholds()
        {
            var requestHousehold = new Household { Name = "Sofia" };
            var request = new HttpRequestMessage(HttpMethod.Post, "/households");
            request.Content = new StringContent(requestHousehold.ToJson(), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var household = Household.FromJson(responseAsString);
            householdId = household.Id;
        }

        [Test]
        [Order(2)]
        public async Task CreateUsers()
        {
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../Jsons/households.json");
            var users = User.ListFromJson(File.ReadAllText(path));
            users.ForEach(u => u.HouseholdId = (long)householdId);

            for (int i = 0; i < 2; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "/users");
                request.Content = new StringContent(users[random.Next(0, 3)].ToJson(), Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();

                var responseUseer = User.UserFromJson(responseAsString);
                wishlistIds.Add(responseUseer.WishlistId);
            }
        }

        [Test]
        [Order(3)]
        public async Task GetBooks()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/books");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            listOfBooks = Book.ListFromJson(responseAsString);
        }

        [Test]
        [Order(4)]
        public async Task AddBookToWishlist()
        {
            foreach (var wishlistId in wishlistIds)
            {
                var bookId = listOfBooks[random.Next(0, listOfBooks.Count)].Id;
                var request = new HttpRequestMessage(HttpMethod.Post, $"/wishlists/{wishlistId}/books/{bookId}");
                request.Content = new StringContent("", Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
        }

        [Test]
        [Order(5)]
        public async Task GetHouseholdBooks()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/households/{householdId}/wishlistBooks");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var books = Book.ListFromJson(responseAsString);

            books.Count.Should().BeGreaterThan(0);
        }
    }
}
