# Containerized integration testing for Boxed API

This example shows the integration tests for boxed-templates running against a SQL Server container instead of a mock repository.

I might write a blog post but here are some good ones to get you started:

- https://wright-development.github.io/post/using-docker-for-net-core/
- Alternative way using a docker C# client https://medium.com/@bappertdennis/containerized-integration-testing-for-asp-net-core-95807f107297

Boxed: https://github.com/Dotnet-Boxed/Templates/blob/master/Docs/API.md

## General steps I did

- `dotnet new api -do --name DockerTemplate`
- Add efcore stuff
- Update repos to use EF core
- Update program.cs to seed data
- Add docker-compose, and dockerfile for tests
- Modify dockerfile for api and remove `dotnet test` stuff

Not all tests pass, just enough to prove the concept works.

## testing

- `git clone https://github.com/VictorioBerra/core3-containerized-integration.git`
- `cd core3-containerized-integration`
- `docker-compose -f .\Tests\DockerTemplate.IntegrationTest\docker-compose-integration.yml up --remove-orphans --build`

## See docker-compose-integration for ENV vars

Its not perfect, but its a starting point for doing this yourself. My motivation is that I am using Dapper and integrating with a ton of old school SPROCs. Having a real SQL Server for me to seed with mock SPROCs lets me leverage WAF/TestServer to the fullest.