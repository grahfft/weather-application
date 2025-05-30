using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace WeatherApplication.Tests;

public class GetCurrentWeatherTests
{
    [Fact]
    public void GetCurrentWeather_ShouldReturnWeatherForecast()
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
            .Returns(forecast);

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345";

        var query = new GetCurrentWeatherQueryRequest();
        query.unit = "F";

        var response = weatherController.GetCurrentWeather(route,query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.CurrentTemperature, forecast.CurrentTemperature);
    }

    [Fact]
    public void GetCurrentWeather_ShouldReturnWeatherForecastFullZipcode()
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
            .Returns(forecast);

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345-1234";

        var query = new GetCurrentWeatherQueryRequest();
        query.unit = "C";

        var response = weatherController.GetCurrentWeather(route,query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.CurrentTemperature, forecast.CurrentTemperature);
    }
}