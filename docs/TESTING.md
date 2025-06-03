# Testing

## Writing a Test and Testing Philosophy

The testing philosophy of this service is to focus on testing behaviors as opposed to testing ALL methods.

This means testing to make sure a particular behavior of the system occurred. This produces less tests with the same coverage as traditional methods.

This testing suite uses [xUnit](https://xunit.net/) and [Moq](https://github.com/devlooped/moq) to develop accomplish this goal.

## Executing automated Tests
Running the below command will execute all automated tests in the below system

```dotnet test```

Executes tests within the test project

## Exploratory Testing

Exploratory Testing is done via Swagger. This is used to find issues automated testing can't find.

Running Swagger can be found [here](RUNNING.md)

## Contract Testing

It should be noted that the HttpClient is embedded into the OpenWeatherRepository class. This is done by design.

If this were a real project, I would advocated for contract testing that spins up this repository and tests against the actual API.

This type of testing can be expensive and complex since we don't have an internal contract to ingest. For this reason alone, I have skipped this form of testing for this small project.

## Future Testing States

There are even more ways we can test this service. There are higher level behavorial tests that can be written.

These tests would be written from the actions of our End Users and map their User Journeys.

I have Skipped this testing as this service is too small to incorporate this type of testing.