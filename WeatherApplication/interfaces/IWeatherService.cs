public interface IWeatherService
{
    public WeatherForecast getCurrentForecast(string zipcode, string unit);
}