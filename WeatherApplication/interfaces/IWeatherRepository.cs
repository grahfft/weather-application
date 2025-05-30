public interface IWeatherRepository
{
    public WeatherForecast getCurrentForecast(string zipcode, string unit);
}