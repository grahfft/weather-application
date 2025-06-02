using Moq;

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
            .Setup(mock => mock.getAverageForecastAsync(It.IsAny<string>(), It.IsAny<WeatherUnit>()))
            .Returns(Task.FromResult(forecast));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.Zipcode = "12345";

        var query = new GetCurrentWeatherQueryRequest();
        query.Units = WeatherUnit.Fahrenheit.ToString();

        var response = await weatherController.GetCurrentWeather(route,query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.AverageTemperature, forecast.AverageTemperature);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldReturnWeatherForecastFullZipcode()
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
            .Setup(mock => mock.getAverageForecastAsync(It.IsAny<string>(), It.IsAny<WeatherUnit>()))
            .Returns(Task.FromResult(forecast));

        var weatherService = new WeatherService(mockWeatherRepo.Object);
        var weatherController = new WeatherController(weatherService);

        var route = new GetCurrentWeatherRouteRequest();
        route.Zipcode = "12345-1234";

        var query = new GetCurrentWeatherQueryRequest();
        query.Units = WeatherUnit.Celsius.ToString();

        var response = await weatherController.GetCurrentWeather(route,query);
        Assert.NotNull(response.Value);
        Assert.Equal(response.Value.AverageTemperature, forecast.AverageTemperature);
    }
}