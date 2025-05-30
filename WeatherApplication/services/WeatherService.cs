using System.Text.RegularExpressions;

public class WeatherService : IWeatherService
{
    private IWeatherRepository weatherRepository;

    public WeatherService(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }
    public WeatherForecast getCurrentForecast(string zipcode, string unit)
    {
        Regex zipcodeValidationRegex = new Regex("^[0-9]{5}(?:-[0-9]{4})?$");
        if (!zipcodeValidationRegex.IsMatch(zipcode))
        {
            throw new InvalidZipcodeException("Zipcode is invalid. Must be xxxxx or xxxxx-xxxx");
        }

        return this.weatherRepository.getCurrentForecast(zipcode, unit);
    }
}