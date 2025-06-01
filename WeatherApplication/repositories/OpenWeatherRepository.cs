using System.Web;
using Newtonsoft.Json;

public class OpenWeatherRepository : IWeatherRepository
{
    private HttpClient client = new();
    public async Task<WeatherForecast> getCurrentForecast(string zipcode, string unit)
    {
        // TODO Create enum for easy mapping of Fahrenheit -> Imperial and back for unit mapping
        var uriBuilder = new UriBuilder($"https://api.openweathermap.org/data/2.5/weather");
        var parameters = HttpUtility.ParseQueryString(string.Empty);
        parameters["zip"] = zipcode.Substring(0, 5);
        parameters["appid"] = "4783376f20ba8dec300467cb4d4cb209";
        parameters["units"] = "imperial";
        uriBuilder.Query = parameters.ToString();

        Uri uri = uriBuilder.Uri;
        var response = await this.client.GetAsync(uri);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        // Console.WriteLine($"{jsonResponse}");

        var openWeatherForecast = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherForecast>(jsonResponse);
        Console.WriteLine($"{JsonConvert.SerializeObject(openWeatherForecast)}");

        return new WeatherForecast
            (
                (int)openWeatherForecast.main.temp,
                unit,
                openWeatherForecast.coord.lat,
                openWeatherForecast.coord.lon,
                openWeatherForecast.weather.Exists(report => report.main == "Rain" || report.main == "Drizzle")
            );
    }
}