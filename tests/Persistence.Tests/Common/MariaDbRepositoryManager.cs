namespace Persistence.Tests.Common;

public class MariaDbRepositoryManager : IRepositoryManager
{
    private readonly ServiceProvider _serviceProvider;
    public IPlayerRepository PlayerRepository { get; }

    public MariaDbRepositoryManager()
    {
        var services = new ServiceCollection();
        IConfiguration configuration = EnvConfigurationBuilder.Instance;
        services.AddSingleton<IPasswordHasher, FakePasswordHasher>();
        services.AddPersistenceMariaDBServices(configuration);
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
        var settings = _serviceProvider.GetRequiredService<MariaDbSettings>();
        var sqlCollection = _serviceProvider.GetRequiredService<ISqlCollection>();
        using var connection = new MySqlConnection(settings.ConnectionString);
        connection.Open();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = sqlCollection["InitializeSeedData"];
        command.ExecuteNonQuery();
    }
}
