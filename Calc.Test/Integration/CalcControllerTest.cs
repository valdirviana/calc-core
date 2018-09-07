using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
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

        [Theory]
        [InlineData("100", "5", "105.1")]
        [InlineData("234", "5", "245.93")]
        [InlineData("985,96", "2", "1005.77")]
        [InlineData("15", "1", "15.15")]
        [InlineData("1", "25", "1.28")]
        [InlineData("1256,6942", "75", "2650.52")]
        [InlineData("75,123654", "360", "2700.66")]
        [InlineData("423,36", "21", "521.74")]
        [InlineData("154,6", "33", "214.69")]
        public async Task calculajuros_Get_Returns_compoundInterest(string amount, string period, string finalAmount)
        {
            var response = await _client.GetAsync($"/calculajuros?valorinicial={amount}&meses={period}");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Be(finalAmount);

            var statusCode = response.StatusCode;
            statusCode.Should().Be(HttpStatusCode.OK);

            Dispose();
        }
    }
}
