using System.ComponentModel.DataAnnotations;

public class GetCurrentWeatherQueryRequest
{
    [Required(AllowEmptyStrings = false)]
    [RegularExpression("^[K|F|C|k|f|c]", ErrorMessage = "Unit is invalid")]
    public string unit { get; set; }
}