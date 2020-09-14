namespace DockerTemplate.IntegrationTest.Fixtures
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using DockerTemplate.Data;
    using DockerTemplate.Options;
    using DockerTemplate.Repositories;
    using DockerTemplate.Services;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using Moq;
    using Serilog;
    using Serilog.Events;
    using Xunit.Abstractions;

    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint>
        where TEntryPoint : class
    {
        public CustomWebApplicationFactory(ITestOutputHelper testOutputHelper)
        {
            this.ClientOptions.AllowAutoRedirect = false;
            this.ClientOptions.BaseAddress = new Uri("https://localhost");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.TestOutput(testOutputHelper, LogEventLevel.Verbose)
                .CreateLogger();
        }

        public ApplicationOptions ApplicationOptions { get; private set; }

        // public Mock<ICarRepository> CarRepositoryMock { get; private set; }
        public Mock<IClockService> ClockServiceMock { get; private set; }

        public void VerifyAllMocks() => Mock.VerifyAll(this.ClockServiceMock);

        protected override void ConfigureClient(HttpClient client)
        {
            using (var serviceScope = this.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                this.ApplicationOptions = serviceProvider.GetRequiredService<IOptions<ApplicationOptions>>().Value;
                // this.CarRepositoryMock = serviceProvider.GetRequiredService<Mock<ICarRepository>>();
                this.ClockServiceMock = serviceProvider.GetRequiredService<Mock<IClockService>>();
            }

            base.ConfigureClient(client);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0022:Use expression body for methods", Justification = "Easier to read for demo purposes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0058:Expression value is never used", Justification = "Easier to read for demo purposes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0053:Use expression body for lambda expressions", Justification = "Easier to read for demo purposes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Easier to read for demo purposes")]
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseEnvironment("Test")
                .UseStartup<TestStartup>();

            if (Environment.GetEnvironmentVariable("UseSqlServer") != "1")
            {
                builder.ConfigureServices(services =>
                {
                    // Remove the app's CarsDbContext registration.
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<CarsDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    services.AddDbContext<CarsDbContext>(options =>
                    {
                        options
                            .UseInMemoryDatabase("WuitCMDBInMemory");
                    });

                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var context = scopedServices.GetRequiredService<CarsDbContext>();

                        context.Database.EnsureDeleted();

                        context.Database.EnsureCreated();

                        context.Cars.AddRange(CarData.Get());
                        context.SaveChanges();
                    }
                });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.VerifyAllMocks();
            }

            base.Dispose(disposing);
        }
    }
}
