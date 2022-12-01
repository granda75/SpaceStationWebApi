using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpaceStationWebApi.Models;


namespace SpaceStationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        private readonly IConfiguration _configuration;

        public SpaceController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetLocation")]
        public async Task<SpaceStationLocation> GetLocationAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var spaceUrl = _configuration.GetValue<string>("SpaceURL");
            using (var response = await httpClient.GetAsync(spaceUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                string responseAsString = await response.Content.ReadAsStringAsync();
                var stationLocation = JsonConvert.DeserializeObject<SpaceStationLocation>(responseAsString);
                return stationLocation;
            }
        }
    }
}
