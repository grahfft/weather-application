using System.Web;

public class OpenWeatherRepository : IWeatherRepository
{
    private HttpClient client = new();
    public async Task<WeatherForecast> getCurrentForecast(string zipcode, string unit)
    {
        // var uriBuilder = new UriBuilder($"http://localhost:5183/Weather/Current/{this.Zipcode}");
        // var parameters = HttpUtility.ParseQueryString(string.Empty);
        // parameters["unit"] = "";
        // uriBuilder.Query = parameters.ToString();

        // Uri uri = uriBuilder.Uri;
        // var response = await this.client.GetAsync(uri);

        // var jsonResponse = await response.Content.ReadAsStringAsync();
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