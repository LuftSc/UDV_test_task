using UssJuniorTest.Abstractions;
using UssJuniorTest.Infrastructure.Repositories;
using UssJuniorTest.Infrastructure.Store;
using UssJuniorTest.Services;

namespace UssJuniorTest;

public static class ServiceCollectionExtensions
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddSingleton<IStore, InMemoryStore>();

        services.AddScoped<CarRepository>();
        services.AddScoped<PersonRepository>();
        services.AddScoped<DriveLogRepository>();

        services.AddScoped<IDriveLogService, DriveLogService>();
    }
}