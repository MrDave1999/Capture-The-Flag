namespace Persistence.InMemory;

public static class PersistenceInMemoryServicesExtensions
{
    public static IServiceCollection AddPersistenceInMemoryServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        PlayerIdValueGenerator.Instance.Reset();
        Dictionary<int, FakePlayer> players = FakePlayerSeedData.Create();
        services.AddSingleton<IPlayerRepository, FakePlayerRepository>();
        services.AddSingleton(players);
        return services;
    }
}
