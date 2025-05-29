using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace WeatherApplication.Tests;

public class WeatherControllerTests
{
    [Fact]
    public void GetCurrentForecast_ShouldReturnWeatherForecast()
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

        var response = weatherController.GetCurrentWeather("1234", "F");
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.CurrentTemperature, forecast.CurrentTemperature);
    }
}