using Microsoft.AspNetCore.Mvc;

[Route("/Weather/Current")]
[ApiController]
public class CurrentWeatherController : ControllerBase
{
    [HttpGet("{zipcode}")]
    public async Task<ActionResult<WeatherForecast>> GetCurrentWeather(string zipcode)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // var forecast = Enumerable.Range(1, 5).Select(index =>

        // .ToArray();

        var forecast = new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(0)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        );

        return forecast;
    }
}