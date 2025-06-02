public interface IWeatherService
{
    public Task<CurrentForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit);
}