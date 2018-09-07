using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Calc.Test.Integration
{
    public class CalcControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public CalcControllerTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        internal void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Fact]
        public async Task Index_Get_ReturnsIndexHtmlPage()
        {
            // Act
            var response = await _client.GetAsync("/calculajuros?valorinicial=123,25&meses=2");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>Home Page - BlogPlayground</title>", responseString);

            Dispose();
        }
    }
}
