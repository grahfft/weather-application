public interface IWeatherRepository
{
    public Task<WeatherForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit);
}