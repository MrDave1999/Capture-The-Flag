namespace CTF.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ServerTimeService>()
            .AddPlayerServices()
            .AddMapServices()
            .AddTeamServices();

        return services;
    }
}
