using System.ComponentModel.DataAnnotations;

public class GetCurrentWeatherQueryRequest
{
    [Required(AllowEmptyStrings = false)]
    public string unit { get; set; }
}