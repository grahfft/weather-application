public interface IWeatherService
{
    public Task<CurrentForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit);

    public Task<AverageForecast> getAveragetForecastAsync(string zipcode, WeatherUnit unit, int count);
}