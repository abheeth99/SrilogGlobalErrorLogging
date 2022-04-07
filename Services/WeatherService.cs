using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SrilogGlobalErrorLogging.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherService()
        {
        }

        public WeatherForecast AddWeather(string newWeather)
        {
            throw new NotImplementedException();
        }

        public WeatherForecast DeleteWeather(int id)
        {
            throw new NotImplementedException();
        }

        public WeatherForecast[] GetAllWeather()
        {
            throw new NotImplementedException();

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

        public WeatherForecast UpdateWeather(string updatedWeather)
        {
            throw new NotImplementedException();
        }
    }
}