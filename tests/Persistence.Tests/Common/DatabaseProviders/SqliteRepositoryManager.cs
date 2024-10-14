namespace Persistence.Tests.Common.DatabaseProviders;

public class SqliteRepositoryManager : IRepositoryManager
{
    private readonly ServiceProvider _serviceProvider;
    public IPlayerRepository PlayerRepository { get; }
    public SqliteRepositoryManager()
    {
        var services = new ServiceCollection();
        IConfiguration configuration = EnvConfigurationBuilder.Instance;
        services.AddSingleton<IPasswordHasher, FakePasswordHasher>();
        services.AddPersistenceSQLiteServices(configuration);
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
        var settings = _serviceProvider.GetRequiredService<SQLiteSettings>();
        var sqlCollection = _serviceProvider.GetRequiredService<ISqlCollection>();
        using var connection = new SqliteConnection(settings.ConnectionString);
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = sqlCollection["InitializeSeedData"];
        command.ExecuteNonQuery();
    }
}
