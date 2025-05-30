using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace WeatherApplication.Tests;

public class WeatherControllerTests
{
    [Fact]
    public void GetCurrentForecast_Return400OnInvalidLocation()
    {
        // TODO: Figure out Httpclient generation and test fixtures to generate validation errors
    }
}