using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class WeatherController : ControllerBase
{
    private IWeatherService weatherService;
    public WeatherController(IWeatherService weatherService)
    {
        this.weatherService = weatherService;
    }

    [Route("/Weather/Current/{zipcode}")]
    [HttpGet]
    public async Task<ActionResult<WeatherForecast>> GetCurrentWeather([FromRoute] GetCurrentWeatherRouteRequest route, [FromQuery] GetCurrentWeatherQueryRequest query)
    {
        try
        {
            return await this.weatherService.getCurrentForecastAsync(route.zipcode, query.unit.ToWeatherUnit());
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

    [Route("/Weather/Average/{zipcode}")]
    [HttpGet]
    public async Task<ActionResult<WeatherForecast>> GetAverageForecast([FromRoute] GetCurrentWeatherRouteRequest route, [FromQuery] GetCurrentWeatherQueryRequest query)
    {
        throw new NotImplementedException("not set up");
        // try
        // {
        //     return await this.weatherService.getAveragetForecastAsync(route.zipcode, query.Units.ToWeatherUnit(), 5);
        // }
        // catch (Exception ex)
        // {
        //     var problemDetails = new ProblemDetails
        //     {
        //         Status = (int)HttpStatusCode.InternalServerError,
        //         Title = "Internal Server Error",
        //         Detail = ex.Message,
        //     };

        //     return new ObjectResult(problemDetails)
        //     {
        //         StatusCode = (int)HttpStatusCode.InternalServerError
        //     };
        // }
    }
}