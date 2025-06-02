public class WeatherForecast
{
    public WeatherForecast(int currentTemperature, string unit, double lat, double lon, Boolean rainPossibleToday)
    {
        this.CurrentTemperature = currentTemperature;
        this.Unit = unit;
        this.Lat = lat;
        this.Lon = lon;
        this.RainPossibleToday = rainPossibleToday;
    }

    public int CurrentTemperature { get; }
    public string Unit { get; }

    public double Lat { get; }
    public double Lon { get; }

    public Boolean RainPossibleToday { get; }
}