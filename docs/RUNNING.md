# Running Weather Service

the commands below expect you to be running this at the solution level

### Building

The solution is set up to run a build of all project in the solution. Running the build command will produce a build for the WeatherApplication project

```dotnet build```

### Run
The server can also be built by running the below command against it. It's not the primary function as this command is used to start up the service locally.

```dotnet run --project WeatherApplication/WeatherApplication.csproj```

An alternative to this command is to go into the project directory and execute the run command

```
cd WeatherApplication

dotnet run
```

Either command should start the server up on `localhost:5183`

### Swagger

You can use the below swagger link to verify the service is up and running

```http://localhost:5183/swagger```