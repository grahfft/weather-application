using Microsoft.AspNetCore.Mvc;

[Route("/Weather/Current")]
[ApiController]
public class CurrentWeatherController : ControllerBase
{
    private IWeatherService weatherService;
    public CurrentWeatherController(IWeatherService weatherService)
    {
        this.weatherService = weatherService;
    }

    [HttpGet("{zipcode}")]
    public ActionResult<WeatherForecast> GetCurrentWeather(string zipcode, string unit = "F")
    {
        return this.weatherService.getCurrentForecast(zipcode, unit);
    }
}