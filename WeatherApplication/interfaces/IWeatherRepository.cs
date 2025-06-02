public interface IWeatherRepository
{
    public Task<CurrentForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit);

    public Task<AverageForecast> getAverageForecastAsync(string zipcode, WeatherUnit unit, int count);
}