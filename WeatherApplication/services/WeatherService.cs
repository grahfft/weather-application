public class WeatherService : IWeatherService
{
    private IWeatherRepository weatherRepository;

    public WeatherService(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }

    public async Task<AverageForecast> getAverageForecastAsync(string zipcode, WeatherUnit unit, int count)
    {
        return await this.weatherRepository.getAverageForecastAsync(zipcode, unit, count);
    }

    public async Task<CurrentForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit)
    {
        return await this.weatherRepository.getCurrentForecastAsync(zipcode, unit);
    }
}