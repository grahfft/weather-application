using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class WeatherService : IWeatherService
{
    private IWeatherRepository weatherRepository;

    public WeatherService(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }
    public async Task<WeatherForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit)
    {
        return await this.weatherRepository.getCurrentForecastAsync(zipcode, unit);
    }
}