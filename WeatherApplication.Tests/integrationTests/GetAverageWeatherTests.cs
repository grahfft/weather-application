using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Namotion.Reflection;

namespace WeatherApplication.Tests;

public class GetAverageWeatherTests
{
    [Fact]
    public async Task GetAverageWeather_ShouldReturnWeatherForecast()
    {
        var forecast = new AverageForecast
            (
                60,
                "F",
                45.67,
                54.36,
                true
            );
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        mockWeatherRepo
            .Setup(mock => mock.getAverageForecastAsync(It.IsAny<string>(), It.IsAny<WeatherUnit>(), It.IsAny<int>()))
            .Returns(Task.FromResult(forecast));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345";

        var query = new GetAverageWeatherQueryRequest();
        query.unit = WeatherUnit.Fahrenheit.ToString();
        query.count = 4;

        var response = await weatherController.GetAverageForecast(route, query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.AverageTemperature, forecast.AverageTemperature);
    }

    [Fact]
    public async Task GetAverageWeather_ShouldReturnWeatherForecastFullZipcode()
    {
        var forecast = new AverageForecast
            (
                60,
                "F",
                45.67,
                54.36,
                true
            );
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        mockWeatherRepo
            .Setup(mock => mock.getAverageForecastAsync(It.IsAny<string>(), It.IsAny<WeatherUnit>(), It.IsAny<int>()))
            .Returns(Task.FromResult(forecast));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345-1234";

        var query = new GetAverageWeatherQueryRequest();
        query.unit = WeatherUnit.Celsius.ToString();
        query.count = 2;

        var response = await weatherController.GetAverageForecast(route, query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.AverageTemperature, forecast.AverageTemperature);
    }

    [Fact]
    public async Task GetAverageWeather_ShouldReturnErrorWhenZipcodeNotFoundExceptionThrown()
    {
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        mockWeatherRepo
            .Setup(mock => mock.getAverageForecastAsync(It.IsAny<string>(), It.IsAny<WeatherUnit>(), It.IsAny<int>())).Throws(new ZipcodeNotFoundException("Test"));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345";

        var query = new GetAverageWeatherQueryRequest();
        query.unit = WeatherUnit.Fahrenheit.ToString();
        query.count = 4;

        var response = await weatherController.GetAverageForecast(route, query);
        var details = response.Result.TryGetPropertyValue<ProblemDetails>("Value");
        Assert.Equal((int)HttpStatusCode.NotFound, details.Status);
        Assert.Equal("Zipcode Not Found", details.Title);
    }
    
    [Fact]
    public async Task GetAverageWeather_ShouldReturnErrorWhenExceptionHit()
    {
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        mockWeatherRepo
            .Setup(mock => mock.getAverageForecastAsync(It.IsAny<string>(), It.IsAny<WeatherUnit>(), It.IsAny<int>())).Throws(new NotImplementedException("Test"));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.zipcode = "12345";

        var query = new GetAverageWeatherQueryRequest();
        query.unit = WeatherUnit.Fahrenheit.ToString();
        query.count = 4;

        var response = await weatherController.GetAverageForecast(route, query);
        var details = response.Result.TryGetPropertyValue<ProblemDetails>("Value");
        Assert.Equal( (int)HttpStatusCode.InternalServerError, details.Status);
    }
}