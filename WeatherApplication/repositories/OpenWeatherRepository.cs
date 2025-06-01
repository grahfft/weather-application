using System.Web;
using Newtonsoft.Json;

public class OpenWeatherRepository : IWeatherRepository
{
    private HttpClient client = new();
    public async Task<WeatherForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit)
    {
        // TODO Create enum for easy mapping of Fahrenheit -> Imperial and back for unit mapping
        var uriBuilder = new UriBuilder($"https://api.openweathermap.org/data/2.5/weather");
        var parameters = HttpUtility.ParseQueryString(string.Empty);
        parameters["zip"] = zipcode.Substring(0, 5);
        parameters["appid"] = "4783376f20ba8dec300467cb4d4cb209";
        parameters["units"] = unit.ToSystem().ToString();
        uriBuilder.Query = parameters.ToString();

        Uri uri = uriBuilder.Uri;
        var response = await this.client.GetAsync(uri);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var openWeatherForecast = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherForecast>(jsonResponse);

        if (openWeatherForecast == null)
        {
            throw new Exception("Unable to get and parse forecast from openweather");
        }

        return new WeatherForecast
            (
                (int)openWeatherForecast.main.temp,
                unit.ToShorthand().ToString(),
                openWeatherForecast.coord.lat,
                openWeatherForecast.coord.lon,
                openWeatherForecast.weather.Exists(report => report.main == "Rain" || report.main == "Drizzle")
            );
    }
}