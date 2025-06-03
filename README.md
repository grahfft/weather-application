# weather-application
DCU interview Weather Application

### Table of Contents
- [Setup Weather Service](docs/SETUP.md)
- [Running the Service](docs/RUNNING.md)
- [Testing the Service](docs/TESTING.md)

### CLI commands

Command base is `dotnet run --project localweathercli --`

### Installing New CLI tool
Go into tool directory and pack
Go to solution directory and install tool

```
dotnet pack /p:Version=1.0.X

dotnet tool install --add-source ./localweathercli/nupkg localweathercli
```