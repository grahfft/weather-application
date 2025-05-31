public interface IWeatherService
{
    public Task<WeatherForecast> getCurrentForecast(string zipcode, string unit);
}