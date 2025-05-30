using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace WeatherApplication.Tests;

public class WeatherServiceTests
{
    [Fact]
    public void GetCurrentForecast_ShouldThrowOnInvalidLocation()
    {
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        var weatherService = new WeatherService(mockWeatherRepo.Object);

        Assert.Throws<InvalidZipcodeException>(() => weatherService.getCurrentForecast("1", "T"));
    }

    [Fact]
    public void GetCurrentForecast_ShouldThrowOnInvalidLocationFullZipcode()
    {
        var mockWeatherRepo = new Mock<IWeatherRepository>();
        var weatherService = new WeatherService(mockWeatherRepo.Object);

        Assert.Throws<InvalidZipcodeException>(() => weatherService.getCurrentForecast("12345-12345", "T"));
    }
}