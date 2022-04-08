namespace SrilogGlobalErrorLogging.Services.WeatherService
{
    public interface IWeatherService
    {
        WeatherForecast[] GetAllWeather();
        string GetWeatherById(int id);
        public void ThrowError();
    }
}
