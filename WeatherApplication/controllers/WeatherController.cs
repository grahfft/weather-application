using Microsoft.AspNetCore.Mvc;

[Route("/Weather/Current")]
[ApiController]
public class WeatherController : ControllerBase
{
    private IWeatherService weatherService;
    public WeatherController(IWeatherService weatherService)
    {
        this.weatherService = weatherService;
    }

    [HttpGet("{zipcode}")]
    public ActionResult<WeatherForecast> GetCurrentWeather([FromRoute] GetCurrentWeatherRouteRequest route, [FromQuery] GetCurrentWeatherQueryRequest query)
    {
        return this.weatherService.getCurrentForecast(route.zipcode, query.unit);
    }
}