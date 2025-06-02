public class OpenWeatherCurrentForecast
{
    public Coordinates coord { get; set; }

    public MainBody main { get; set; }

    public List<Weather> weather { get; set; }
}

public class OpenWeatherAverageForecast
{
    public List<FutureForecasts> list { get; set; }

    public City city { get; set; }
}

public class FutureForecasts
{
    public MainBody main { get; set; }

    public List<Weather> weather { get; set; }
}

public class City
{
    public Coordinates coord { get; set; }
}

public class MainBody
{
    public double temp { get; set; }
}

public class Coordinates
{
    public double lat { get; set; }

    public double lon { get; set; }
}

public class Weather
{
    public string main { get; set; }
}