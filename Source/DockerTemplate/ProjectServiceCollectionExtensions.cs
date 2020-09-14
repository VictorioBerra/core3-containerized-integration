namespace DockerTemplate
{
    using Boxed.Mapping;
    using DockerTemplate.Commands;
    using DockerTemplate.Mappers;
    using DockerTemplate.Repositories;
    using DockerTemplate.Services;
    using DockerTemplate.ViewModels;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddScoped<IDeleteCarCommand, DeleteCarCommand>()
                .AddScoped<IGetCarCommand, GetCarCommand>()
                .AddScoped<IGetCarPageCommand, GetCarPageCommand>()
                .AddScoped<IPatchCarCommand, PatchCarCommand>()
                .AddScoped<IPostCarCommand, PostCarCommand>()
                .AddScoped<IPutCarCommand, PutCarCommand>();

        public static IServiceCollection AddProjectMappers(this IServiceCollection services) =>
            services
                .AddSingleton<IMapper<Models.Car, Car>, CarToCarMapper>()
                .AddSingleton<IMapper<Models.Car, SaveCar>, CarToSaveCarMapper>()
                .AddSingleton<IMapper<SaveCar, Models.Car>, CarToSaveCarMapper>();

        public static IServiceCollection AddProjectRepositories(this IServiceCollection services) =>
            services
                .AddScoped<ICarRepository, CarRepository>();

        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services
                .AddSingleton<IClockService, ClockService>();
    }
}
