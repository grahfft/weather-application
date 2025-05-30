
using DotMake.CommandLine;
Cli.Run<RootWithNestedChildrenCliCommand>(args);


[CliCommand(Description = "A root cli command with nested children")]
public class RootWithNestedChildrenCliCommand
{

    [CliArgument(Description = "subcommand you want to run")]
    public string command { get; set; } = "get-current-weather";

    public void Run(CliContext context)
    {
        if (context.IsEmptyCommand())
            context.ShowHierarchy();
        else
            context.ShowValues();
    }

    [CliCommand(Description = "Gets the Current Weather for a given Zipcode")]
    public class GetCurrentWeatherSubCliCommand
    {
        [CliOption(Description = "Description for Option1")]
        public string Option1 { get; set; } = "DefaultForOption1";

        [CliArgument(Description = "Where you want to get the weather")]
        public string zipcode { get; set; }

         [CliArgument(Description = "Unit of Measure of the temperature ")]
        public string unit { get; set; }

        public void Run(CliContext context)
        {
            
        }
    }
}