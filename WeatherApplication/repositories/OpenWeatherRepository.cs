using System.Web;
using Newtonsoft.Json;

public class OpenWeatherRepository : IWeatherRepository
{
    private HttpClient client = new();

    private const string CURRENT_FORECAST_ENDPOINT = "https://api.openweathermap.org/data/2.5/weather";

    private const string AVERAGE_FORECAST_ENDPOINT = "https://api.openweathermap.org/data/2.5/forecast";

    public async Task<CurrentForecast> getCurrentForecastAsync(string zipcode, WeatherUnit unit)
    {
        var uri = this.buildUri(CURRENT_FORECAST_ENDPOINT, zipcode, unit);
        var response = await this.client.GetAsync(uri);

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            throw new ZipcodeNotFoundException("Zipcode not found");
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to got a response from OpenWeather");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var openWeatherForecast = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherCurrentForecast>(jsonResponse);

        if (openWeatherForecast == null)
        {
            throw new Exception("Unable to parse OpenWeather response");
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


    public async Task<AverageForecast> getAverageForecastAsync(string zipcode, WeatherUnit unit, int count)
    {
        var uri = this.buildUri(AVERAGE_FORECAST_ENDPOINT, zipcode, unit, count);
        var response = await this.client.GetAsync(uri);

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            throw new ZipcodeNotFoundException("Zipcode not found");
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to got a response from OpenWeather");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var openWeatherForecast = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherAverageForecast>(jsonResponse);

        if (openWeatherForecast == null)
        {
            throw new Exception("Unable to parse OpenWeather response");
        }

        double total = 0.0;
        bool rainPossible = false;

        foreach (var forecast in openWeatherForecast.list)
        {
            total += forecast.main.temp;
            rainPossible = rainPossible || forecast.weather.Exists(report => report.main == "Rain" || report.main == "Drizzle");
        }

        return new AverageForecast
            (
                (int)total/openWeatherForecast.cnt,
                unit.ToShorthand().ToString(),
                openWeatherForecast.city.coord.lat,
                openWeatherForecast.city.coord.lon,
                rainPossible
            );
    }

    private Uri buildUri(string baseAddress, string zipcode, WeatherUnit unit, int count = 1)
    {
        var uriBuilder = new UriBuilder(baseAddress);
        var parameters = HttpUtility.ParseQueryString(string.Empty);

        parameters["zip"] = zipcode.Substring(0, 5);
        parameters["appid"] = Environment.GetEnvironmentVariable("OpenWeatherAppId");
        parameters["units"] = unit.ToSystem().ToString();
        parameters["cnt"] = count.ToString();

        uriBuilder.Query = parameters.ToString();
        return uriBuilder.Uri;
    }
}