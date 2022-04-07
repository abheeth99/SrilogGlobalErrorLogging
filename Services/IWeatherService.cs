namespace SrilogGlobalErrorLogging.Services.WeatherService
{
    public interface IWeatherService
    {
        WeatherForecast[] GetAllWeather();
        string GetWeatherById(int id);
        WeatherForecast AddWeather(string newWeather);
        WeatherForecast UpdateWeather(string updatedWeather);
        WeatherForecast DeleteWeather(int id);
    }
}
