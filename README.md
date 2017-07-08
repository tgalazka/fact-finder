# fact-finder
A sample C# Visual Studio REST API to separate fact from fiction.

## Development
Server runs in local IIS on port 50146; click the run button in studio to launch.

## Documentation
This projects imploys C-doc driven documentation for all of the classes resulting in a `FactFinder.xml` file on build in the `bin` directory.

As a data API, there are also Swagger documents for the controllers, documenting the resources available.
To review them, launch the solution and navigate to the (Swagger UI)[http://localhost:50146/swagger] on the running server.