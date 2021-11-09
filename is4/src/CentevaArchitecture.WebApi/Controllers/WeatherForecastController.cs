using CentevaArchitecture.Application.WeatherForecasts;
using Microsoft.AspNetCore.Mvc;

namespace CentevaArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Task<List<WeatherForecastDto>> Get()
        {
            return Mediator.Send(new GetWeatherForecastQuery());
        }
    }
}