Running the API (Development)

When this project starts in Development configuration, it logs the URLs it is listening on, along with links to the Swagger UI and OpenAPI contract.

Example output:

PS C:\aimelevator\AIMElevator.api> dotnet run
Using launch settings from C:\aimelevator\AIMElevator.api\Properties\launchSettings.json...
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:8080
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\aimelevator\AIMElevator.api
info: Program[0]
      Application running at: http://localhost:8080
info: Program[0]
      Swagger UI available at: http://localhost:8080/swagger
info: Program[0]
      OpenAPI contract: http://localhost:8080/swagger/v1/swagger.json

API Discovery & Testing

Developers can explore and test the API endpoints using:

Swagger UI
http://localhost:8080/swagger

OpenAPI contract (swagger.json)
http://localhost:8080/swagger/v1/swagger.json

The OpenAPI contract can be imported into tools such as Postman, Insomnia, or used to generate sample client code in most languages.

Port Configuration

If you encounter port conflicts, the listening port can be changed by updating:

Properties/launchSettings.json


Alternatively, ports can be overridden using environment variables such as:

ASPNETCORE_URLS