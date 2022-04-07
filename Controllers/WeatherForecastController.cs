using Microsoft.AspNetCore.Mvc;
using SrilogGlobalErrorLogging.Services.WeatherService;

namespace SrilogGlobalErrorLogging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _WeatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            _WeatherService = weatherService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _WeatherService.GetAllWeather();
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return _WeatherService.GetWeatherById(id);
        }
    }
}