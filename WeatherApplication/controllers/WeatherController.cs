using System.Net;
using System.Threading.Tasks;
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
    public async Task<ActionResult<CurrentForecast>> GetCurrentWeather([FromRoute] GetCurrentWeatherRouteRequest route, [FromQuery] GetCurrentWeatherQueryRequest query)
    {
        try
        {
            return await this.weatherService.getCurrentForecastAsync(route.Zipcode, query.Units.ToWeatherUnit());
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