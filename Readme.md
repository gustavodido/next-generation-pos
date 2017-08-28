
dotnet add WebApi.csproj package Evolve
dotnet add WebApi.csproj package Npgsql
dotnet run -p src/WebApi/WebApi.csproj

 dotnet add WebApi.Tests.csproj package FakeItEasy

dotnet add WebApi.csproj package Dapper

 dotnet add WebApi.Tests.csproj reference ../../src/WebApi/WebApi.csproj

TODO
Implement HATEOAS
Logging
Error Handling
Integration Tests