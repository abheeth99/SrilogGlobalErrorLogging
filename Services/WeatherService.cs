using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SrilogGlobalErrorLogging.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;

        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }

        public WeatherForecast[] GetAllWeather()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public string GetWeatherById(int id)
        {
            return Summaries[id];
        }

        public void ThrowError()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"This is a LogDebug {ex}");
                _logger.LogInformation($"This is a LogInfor {ex}mation");
                _logger.LogWarning($"This is a LogWarni {ex}ng");
                _logger.LogError($"This is a LogError {ex}");
                _logger.LogCritical($"This is a LogCriti {ex}cal");

                throw;
            }
        }
    }
}