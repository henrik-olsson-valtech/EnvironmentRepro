This is a reproduction of a problem with ASP.NET Core 2.1 web API reads environment from environment
variable ASPNETCORE_ENVIRONMENT with "normal" Kestrel hosting but not when hosted in a test.

To reproduce:
1. Open a command prompt.
2. Set environment name: `set ASPNETCORE_ENVIRONMENT=Staging`
3. Confirm that ASPNETCORE_ENVIRONMENT is **not** set in `Properties\launchSettings.json` (in either project).
3. Run the project: `dotnet run --project EnvironmentRepro\EnvironmentRepro.csproj`
4. Open a web browser and go to https://localhost:5001/.
5. It displays _Staging_ as expected.
6. Press CTRL+C.
7. Run the tests: `dotnet test EnvironmentRepro.IntegrationTests\EnvironmentRepro.IntegrationTests.csproj`.
8. I would expect both tests to pass. In reality,
   `Environment_variable_should_be_staging` succeeds but
   `Environment_should_be_set_from_variable` fails.