public class WeatherForecast
{
    public WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        this.Date = Date;
        this.TemperatureC = TemperatureC;
        this.Summary = Summary;
        this.TemperatureF = (int)(TemperatureC / 0.5556);
    }

    public DateOnly Date { get; }
    public int TemperatureC { get; }
    public string? Summary { get; }
    public int TemperatureF { get; }
}