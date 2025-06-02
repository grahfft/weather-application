public interface IWeatherRepository
{
    public Task<CurrentForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit);
}