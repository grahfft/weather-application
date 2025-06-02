using System.ComponentModel.DataAnnotations;

public class GetCurrentWeatherRouteRequest
{
    [Required(AllowEmptyStrings = false)]
    [RegularExpression("^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Zipcode is invalid")]
    public string zipcode { get; set; }
}