public interface IWeatherRepository
{
    public Task<WeatherForecast> getCurrentForecast(string zipcode, string unit);
}