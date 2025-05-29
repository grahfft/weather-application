using Microsoft.AspNetCore.Mvc;

[Route("/Weather/Current")]
[ApiController]
public class CurrentWeatherController : ControllerBase
{
    [HttpGet("{zipcode}")]
    public async Task<ActionResult<WeatherForecast>> GetCurrentWeather(string zipcode, string unit = "F")
    {
        var forecast = new WeatherForecast
        (
            60,
            unit,
            45.67,
            54.36,
            true
        );

        return forecast;
    }
}