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
    public async Task<ActionResult<CurrentForecast>> GetCurrentWeather(
        [FromRoute] GetCurrentWeatherRouteRequest route,
        [FromQuery] GetCurrentWeatherQueryRequest query
        )
    {
        try
        {
            return await this.weatherService.getCurrentForecastAsync(route.zipcode, query.unit.ToWeatherUnit());
        }
        catch (ZipcodeNotFoundException ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Title = "Zipcode Not Found",
                Detail = ex.Message,
            };

            return new ObjectResult(problemDetails)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
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
    public async Task<ActionResult<AverageForecast>> GetAverageForecast(
        [FromRoute] GetCurrentWeatherRouteRequest route, [
        FromQuery] GetCurrentWeatherQueryRequest query)
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