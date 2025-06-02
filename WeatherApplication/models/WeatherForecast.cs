public abstract class WeatherForecast
{
    public WeatherForecast(string unit, double lat, double lon, Boolean rainPossibleToday)
    {
        this.Unit = unit;
        this.Lat = lat;
        this.Lon = lon;
        this.RainPossibleToday = rainPossibleToday;
    }

    
    public string Unit { get; }

    public double Lat { get; }
    public double Lon { get; }

    public Boolean RainPossibleToday { get; }
}

public class CurrentForecast : WeatherForecast
{
    public CurrentForecast(int currentTemperature, string unit, double lat, double lon, bool rainPossibleToday) : base(unit, lat, lon, rainPossibleToday)
    {
        this.CurrentTemperature = currentTemperature;
    }

    public int CurrentTemperature { get; }
}

public class AverageForecast : WeatherForecast
{
    public AverageForecast(int averageTemperature, string unit, double lat, double lon, bool rainPossibleToday) : base(unit, lat, lon, rainPossibleToday)
    {
        this.AverageTemperature = averageTemperature;
    }

    public int AverageTemperature { get; }
}