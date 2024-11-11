namespace CTF.Application.Maps;

public static class MapServicesExtensions
{
    public static IServiceCollection AddMapServices(this IServiceCollection services)
    {
        services
            .AddSingleton<MapInfoService>()
            .AddSingleton<MapRotationService>()
            .AddSingleton<MapTextDrawRenderer>();

        return services;
    }
}
