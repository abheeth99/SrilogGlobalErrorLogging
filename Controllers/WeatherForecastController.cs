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
        public IActionResult Get()
        {
            return Ok(_WeatherService.GetAllWeather());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_WeatherService.GetWeatherById(id));
        }

        [HttpGet("ThrowErr")]
        public void ThrowError()
        {
            _WeatherService.ThrowError();
        }
    }
}