using System.ComponentModel.DataAnnotations;

public class GetCurrentWeatherQueryRequest
{
    [Required(AllowEmptyStrings = false)]
    public string unit { get; set; }
}

public class GetAverageWeatherQueryRequest : GetCurrentWeatherQueryRequest
{
    [Range(2, 5, ErrorMessage = "Day Count needs to be between 2 and 5")]
    public int count { get; set; }
}