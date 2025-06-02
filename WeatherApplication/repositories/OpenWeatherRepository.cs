using System.Web;
using Newtonsoft.Json;

public class OpenWeatherRepository : IWeatherRepository
{
    private HttpClient client = new();
    public async Task<CurrentForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit)
    {
        var uri = this.buildUri(zipcode, unit);
        var response = await this.client.GetAsync(uri);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var openWeatherForecast = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherForecast>(jsonResponse);

        if (openWeatherForecast == null)
        {
            throw new Exception("Unable to get and parse forecast from openweather");
        }

        return new CurrentForecast
            (
                (int)openWeatherForecast.main.temp,
                unit.ToShorthand().ToString(),
                openWeatherForecast.coord.lat,
                openWeatherForecast.coord.lon,
                openWeatherForecast.weather.Exists(report => report.main == "Rain" || report.main == "Drizzle")
            );
    }

    private Uri buildUri(string zipcode, WeatherUnit unit, int count = 1)
    {
        var uriBuilder = new UriBuilder($"https://api.openweathermap.org/data/2.5/weather");
        var parameters = HttpUtility.ParseQueryString(string.Empty);

        parameters["zip"] = zipcode.Substring(0, 5);
        parameters["appid"] = Environment.GetEnvironmentVariable("OpenWeatherAppId");
        parameters["units"] = unit.ToSystem().ToString();
        parameters["cnt"] = count.ToString();

        uriBuilder.Query = parameters.ToString();
        return uriBuilder.Uri;
    }
}