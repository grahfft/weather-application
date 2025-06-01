public interface IWeatherService
{
    public Task<WeatherForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit);
}