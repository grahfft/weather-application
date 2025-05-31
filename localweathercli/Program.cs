
using DotMake.CommandLine;
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
        [CliArgument(Description = "Where you want to get the weather")]
        public string Zipcode { get; set; }

        [CliArgument(Description = "Unit of Measure of the temperature ")]
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
                Console.WriteLine($"{JsonObject.Parse(jsonResponse)}\n");
            }
        }
    }
}