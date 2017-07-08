# fact-finder
A sample C# Visual Studio REST API to separate fact from fiction.

## Installation
This is primarily a learning project so it is meant to only be installed on your local machine.

### Solution
Clone the repository like normal and open the solution in Visual Studio 2017.

### Acquire Dependencies
In order to build and run the project you'll need to retrieve all the dependent components.

#### NuGet Libraries
NuGet libraries are managed by the solution directly so this is largely handled by the solution itself:
1. Open the *Solution Explorer*
2. Right-click the solution, i.e `FactFinder`
3. Select *Restore NuGet Packages*
4. If prompted to accept any library agreements, accept them.
5. If prompted about any dependencies to be added or removed, go ahead and accept the changes.

### Run Service
In both cases, the solution will preform a build and, if the build succeeds, will launch the service automatically.

#### With Visual Studio Debugging Enabled
This option allows you to place breakpoints in Visual Studio and step through the code during exectuion.
1. Navigate to the top-level *Debug* menu.
2. Select *Start Debugging*

#### Without Visual Studio Debugging Enabled
This option will build and launch the service, but is not tied to Visual Studio for debugging.
1. Navigate to the top-level *Debug* menu.
2. Select *Start Without Debugging*

## Documentation
Once the solution is lauched on your local maching using one of the methods described above you'll be able to
use the Swagger-UI that has been generated during the build phase.

Swagger consumes the C-doc comments describing controller methods and combines them with the 
API.NET directives to build an interactive document experience.

You can use the [Project Swagger UI](http://localhost:50146/swagger) to actually interact with the service
running locally and review samples of payloads.