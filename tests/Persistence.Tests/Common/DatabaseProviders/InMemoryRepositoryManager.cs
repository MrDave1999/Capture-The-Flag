namespace Persistence.Tests.Common.DatabaseProviders;

public class InMemoryRepositoryManager : IRepositoryManager
{
    private readonly ServiceProvider _serviceProvider;
    public IPlayerRepository PlayerRepository { get; }
    public InMemoryRepositoryManager()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IPasswordHasher, FakePasswordHasher>();
        services.AddPersistenceInMemoryServices();
        _serviceProvider = services.BuildServiceProvider();
        PlayerRepository = _serviceProvider.GetRequiredService<IPlayerRepository>();
    }

    public void Dispose()
    {
        _serviceProvider.Dispose();
        GC.SuppressFinalize(this);
    }

    public void InitializeSeedData()
    {

    }
}
