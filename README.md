# weather-application
DCU interview Weather Application

### Building

```dotnet build```

Works in the solution directory

### Run

```dotnet run --project WeatherApplication/WeatherApplication.csproj```

Starts the server up on `localhost:5183`

### Swagger

```http://localhost:5183/swagger```

Displays all endpoints of the service

### Testing

```dotnet test```

Executes tests within the test project

### CLI commands

Command base is `dotnet run --project weathercli --`

### Installing New CLI tool
Go into tool directory and pack
Go to solution directory and install tool

```
dotnet pack /p:Version=1.0.X

dotnet tool install --add-source ./localweathercli/nupkg localweathercli
```