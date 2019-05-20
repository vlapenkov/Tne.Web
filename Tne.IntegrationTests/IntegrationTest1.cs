using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tne.Web;
using Tne.Web.Dal;
using Web.Api.IntegrationTests;
using Xunit;
using System.Linq;

namespace Tne.IntegrationTests
{
    public class IntegrationTest1 : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        /*
        [Fact]
        public void Test1()
        {

        }
        */
        private readonly HttpClient _client;

        public IntegrationTest1(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetDevices()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/tneapi/MeteringDevices?year=2018");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var devices = JsonConvert.DeserializeObject<IEnumerable<MeteringDevice>>(stringResponse);
            Assert.NotEmpty(devices);
            Assert.Equal(devices.Count(),3);

        }
    }
}
