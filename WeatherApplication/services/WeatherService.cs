public class WeatherService : IWeatherService
{
    private IWeatherRepository weatherRepository;

    public WeatherService(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }
    public WeatherForecast getCurrentForecast(string zipcode, string unit)
    {
        return this.weatherRepository.getCurrentForecast(zipcode, unit);
    }
}