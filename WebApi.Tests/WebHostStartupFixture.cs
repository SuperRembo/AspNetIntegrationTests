using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using NUnit.Framework;

namespace WebApi.Tests
{

    class WebHostStartupFixture
    {
        readonly WebApplicationFactory<WebHostStartup> factory = new();

        [Test]
        public async Task Should_get_content()
        {
            using var client = factory.CreateClient();

            var response = await client.GetAsync("/");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = await response.Content.ReadAsStringAsync();

            Assert.That(content, Is.EqualTo("Hello World!"));
        }
    }
}
