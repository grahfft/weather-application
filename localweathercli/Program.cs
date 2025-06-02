
using DotMake.CommandLine;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Web;

await Cli.RunAsync<RootWithNestedChildrenCliCommand>(args);

[CliCommand(Description = "A root cli command with nested children")]
public class RootWithNestedChildrenCliCommand
{
    [CliArgument(Description = "subcommand you want to run")]
    public string command { get; set; } = "get-current-weather";

    public async Task RunAsync(CliContext context)
    {
        context.ShowHelp();
    }

    [CliCommand(Description = "Gets the Current Weather for a given Zipcode")]
    public class GetCurrentWeatherSubCliCommand
    {
        [CliOption(Description = "Type of output", AllowedValues = ["text", "json", "yaml"])]
        public string Output { get; set; } = "text";

        [CliArgument(Description = "Where you want to get the weather")]
        public string Zipcode { get; set; }

        [CliArgument(Description = "Unit of Measure of the temperature ", AllowedValues = ["fahrenheit", "celsius", "kelvin"])]
        public string Unit { get; set; }

        private HttpClient client = new();

        public async Task RunAsync(CliContext context)
        {
            if (context.IsEmptyCommand())
            {
                context.ShowHelp();
            }
            else
            {
                Console.WriteLine("Getting Current weather");
                var uriBuilder = new UriBuilder($"http://localhost:5183/Weather/Current/{this.Zipcode}");
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                parameters["unit"] = this.Unit;
                uriBuilder.Query = parameters.ToString();

                Uri uri = uriBuilder.Uri;
                var response = await this.client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var parsedResponse = JsonValue.Parse(jsonResponse);

                 switch (this.Output)
                {
                    case "json":
                        Console.WriteLine($"{parsedResponse}\n");
                        break;
                    case "yaml":
                        Console.WriteLine($"currentTemperature: {parsedResponse["currentTemperature"]}");
                        Console.WriteLine($"unit: {parsedResponse["unit"]}");
                        Console.WriteLine($"lat: {parsedResponse["lat"]}");
                        Console.WriteLine($"lon: {parsedResponse["lon"]}");
                        Console.WriteLine($"rainPossibleToday: {parsedResponse["rainPossibleToday"]}");
                        break;
                    default:
                        Console.WriteLine($"Location: {this.Zipcode}");
                        Console.WriteLine($"Current Temperature: {parsedResponse["currentTemperature"]}°{parsedResponse["unit"]}");
                        Console.WriteLine($"Rain Possible Today: {parsedResponse["rainPossibleToday"]}");
                        break;
                }
            }
        }
    }

    [CliCommand(Description = "Gets the Average Weather for a given Zipcode over 2 - 5 days")]
    public class GetAverageWeatherSubCliCommand
    {
        [CliOption(Description = "Type of output", AllowedValues = ["text", "json", "yaml"])]
        public string Output { get; set; } = "text";

        [CliArgument(Description = "Where you want to get the weather")]
        public string Zipcode { get; set; }

        [CliArgument(Description = "Unit of Measure of the temperature", AllowedValues = ["fahrenheit", "celsius", "kelvin"])]
        public string Unit { get; set; }

        [CliArgument(Description = "Number of days to get the Average")]
        public string Count { get; set; }

        private HttpClient client = new();

        public async Task RunAsync(CliContext context)
        {
            if (context.IsEmptyCommand())
            {
                context.ShowHelp();
            }
            else
            {
                Console.WriteLine("Getting Average weather");
                var uriBuilder = new UriBuilder($"http://localhost:5183/Weather/Average/{this.Zipcode}");
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                parameters["unit"] = this.Unit;
                parameters["count"] = this.Count;
                uriBuilder.Query = parameters.ToString();

                Uri uri = uriBuilder.Uri;
                var response = await this.client.GetAsync(uri);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var parsedResponse = JsonValue.Parse(jsonResponse);

                 switch (this.Output)
                {
                    case "json":
                        Console.WriteLine($"{parsedResponse}\n");
                        break;
                    case "yaml":
                        Console.WriteLine($"averageTemperature: {parsedResponse["averageTemperature"]}");
                        Console.WriteLine($"unit: {parsedResponse["unit"]}");
                        Console.WriteLine($"lat: {parsedResponse["lat"]}");
                        Console.WriteLine($"lon: {parsedResponse["lon"]}");
                        Console.WriteLine($"rainPossibleInPeriod: {parsedResponse["rainPossibleInPeriod"]}");
                        break;
                    default:
                        Console.WriteLine($"Location: {this.Zipcode}");
                        Console.WriteLine($"Average Temperature ({this.Count} Day Forecast): {parsedResponse["averageTemperature"]}°{parsedResponse["unit"]}");
                        Console.WriteLine($"Rain Possible during this time: {parsedResponse["rainPossibleInPeriod"]}");
                        break;
                }
            }
        }
    }
}