using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace WeatherApplication.Tests;

public class GetCurrentWeatherTests
{
    [Fact]
    public async Task GetCurrentWeather_ShouldReturnWeatherForecast()
    {
        var forecast = new WeatherForecast
            (
                60,
                "F",
                45.67,
                54.36,
                true
            );
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        mockWeatherRepo
            .Setup(mock => mock.getCurrentForecast(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(Task.FromResult(forecast));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345";

        var query = new GetCurrentWeatherQueryRequest();
        query.unit = "F";

        var response = await weatherController.GetCurrentWeather(route,query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.CurrentTemperature, forecast.CurrentTemperature);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldReturnWeatherForecastFullZipcode()
    {
        var forecast = new WeatherForecast
            (
                60,
                "F",
                45.67,
                54.36,
                true
            );
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        mockWeatherRepo
            .Setup(mock => mock.getCurrentForecast(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(Task.FromResult(forecast));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345-1234";

        var query = new GetCurrentWeatherQueryRequest();
        query.unit = "C";

        var response = await weatherController.GetCurrentWeather(route,query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.CurrentTemperature, forecast.CurrentTemperature);
    }
}