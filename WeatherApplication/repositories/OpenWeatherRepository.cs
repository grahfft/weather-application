public class OpenWeatherRepository : IWeatherRepository
{
    public WeatherForecast getCurrentForecast(string zipcode, string unit)
    {
        return new WeatherForecast
            (
                60,
                unit,
                45.67,
                54.36,
                true
            );
    }
}