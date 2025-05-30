using System.Net;
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
        try
        {
            return this.weatherService.getCurrentForecast(route.zipcode, query.unit);
        }
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Internal Server Error",
                Detail = ex.Message,
            };

            return new ObjectResult(problemDetails)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}