public abstract class WeatherForecast
{
    public WeatherForecast(string unit, double lat, double lon)
    {
        this.Unit = unit;
        this.Lat = lat;
        this.Lon = lon;
    }

    
    public string Unit { get; }

    public double Lat { get; }
    public double Lon { get; }
}

public class CurrentForecast : WeatherForecast
{
    public CurrentForecast(int currentTemperature, string unit, double lat, double lon, bool rainPossibleToday) : base(unit, lat, lon)
    {
        this.CurrentTemperature = currentTemperature;
    }

    public int CurrentTemperature { get; }
    public bool RainPossibleToday { get; }
}

public class AverageForecast : WeatherForecast
{
    public AverageForecast(int averageTemperature, string unit, double lat, double lon, bool rainPossibleInPeriod) : base(unit, lat, lon)
    {
        this.AverageTemperature = averageTemperature;
        this.RainPossibleInPeriod = rainPossibleInPeriod;
    }

    public int AverageTemperature { get; }

    public bool RainPossibleInPeriod { get; }

}