# Unit Testing Asynchronous Web API Controller Methods with Asynchronous Entity Framework Mocks in .NET 5
The code contains a proof of concept RESTful Web API for working with customers stored in an in-memory database. It supports the following methods and has associated unit tests for:

 - Listing all customers
 - Retrieving a customer
 - Adding a customer
 - Updating a customer
 - Deleting a customer

# Prerequisites
[Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) with `ASP.NET and web development` and `.NET desktop development` workloads installed.

# Running the App
Open the solution and from within Visual Studio press `F5`. The application starts with the Swagger UI which can be used to inspect and invoke the API. The associated unit tests can be run from [Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019).

# References
- [Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio)
- [Unit Testing ASP.NET Web API 2](https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-with-aspnet-web-api)
- [Unit Testing Controllers in ASP.NET Web API 2](https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api)
- [Mocking Entity Framework when Unit Testing ASP.NET Web API 2](https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/mocking-entity-framework-when-unit-testing-aspnet-web-api-2)
- [Iterating with Async Enumerables in C# 8](https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8)