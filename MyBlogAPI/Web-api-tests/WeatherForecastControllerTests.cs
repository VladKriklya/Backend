using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UIL;
using Xunit;

namespace Web_api_tests
{
    public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        HttpClient _client { get; }

        public WeatherForecastControllerTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

      /*  [Fact]
        public async Task Get_Should_Retrieve_Forecast()
        {
            var response = await _client.GetAsync("/weatherforecast");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
            forecast.Should().HaveCount(5)
        }*/
    }
}
