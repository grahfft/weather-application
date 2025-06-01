public enum WeatherUnit
{
    Celsius,
    Fahrenheit,
    Kelvin
}

public enum WeatherUnitShorthand
{
    C,
    F,
    K
}

public enum WeatherSystemUnit
{
    Imperial,
    Standard,
    Metric
}

public static class Extensions
{
    public static WeatherUnitShorthand ToShorthand(this WeatherUnit unit)
    {
        switch (unit)
        {
            case WeatherUnit.Celsius:
                return WeatherUnitShorthand.C;
            case WeatherUnit.Fahrenheit:
                return WeatherUnitShorthand.F;
            case WeatherUnit.Kelvin:
                return WeatherUnitShorthand.K;
            default:
                throw new NotImplementedException("New Weather Unit has been added without shorthand");
        }
    }

    public static WeatherSystemUnit ToSystem(this WeatherUnit unit)
    {
        switch (unit)
        {
            case WeatherUnit.Celsius:
                return WeatherSystemUnit.Metric;
            case WeatherUnit.Fahrenheit:
                return WeatherSystemUnit.Imperial;
            case WeatherUnit.Kelvin:
                return WeatherSystemUnit.Standard;
            default:
                throw new NotImplementedException("New Weather Unit has been added without system");
        }
    }

    public static WeatherUnit ToWeatherUnit(this string unit)
    {
        switch (unit)
        {
            case "K":
            case "k":
            case "kelvin":
            case "Kelvin":
                return WeatherUnit.Kelvin;
            case "C":
            case "c":
            case "celsius":
            case "Celsius":
                return WeatherUnit.Celsius;
            case "F":
            case "f":
            case "Fahrenheit":
            case "fahrenheit":
                return WeatherUnit.Fahrenheit;
            default:
                throw new NotImplementedException("Undefined Weather Unit sent");
        }
    }
}