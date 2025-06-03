# Using the Command Line Tool

## Running the service

[Start the service](RUNNING.md) before executing with the command line

## DotMake

This tool is built using [DotMake CommandLine](https://github.com/dotmake-build/command-line), a tool built ontop of System.CommandLine.

This tool just provides a class based way of creating a CLI in C#.

## CLI commands

Command base is `dotnet run --project localweathercli --`

### get-current-weather

`get-current-weather` will make a call to the service's `Weather/Current/{zipcode}` endpoint.

This command takes two arguments: zipcode and unit of measure:

```get-current-weather 12345 celsius```

this will output into the default text output.

To change output type add `--output json|yaml|text`

### get-average-weather
`get-average-weather` will make a call to the service's `Weather/Average/{zipcode}` endpoint.

This command takes three arguments: zipcode, unit of measure, and number of days:

```get-average-weather 12345 celsius 3```

this will output into the default text output.

To change output type add `--output json|yaml|text`

## Installing New CLI tool
Go into tool directory and pack
Go to solution directory and install tool

```
cd localweathercli
dotnet pack
cd ../
dotnet tool install --add-source ./localweathercli/nupkg localweathercli
```

This will allow you to run these commands using
```dotnet localweathercli```

## Adding new commands
In order to add new commands, you'll need to update the nuget package version to incorporate your changes. The below commands will create the new version and upgrade it for you.

```
cd localweathercli
dotnet pack /p:Version=X.X.X
cd ../
dotnet tool install --add-source ./localweathercli/nupkg localweathercli
```