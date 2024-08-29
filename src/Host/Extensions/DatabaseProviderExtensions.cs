namespace CTF.Host.Extensions;

public static class DatabaseProviderExtensions
{
    public static void ChooseDatabaseProvider(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var providers = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase)
        {
            { "InMemory", () => services.AddPersistenceInMemoryServices(configuration) },
            { "SQLite",   () => services.AddPersistenceSQLiteServices(configuration) },
            { "MariaDb",  () => services.AddPersistenceMariaDBServices(configuration) },
        };

        string selectedProvider = configuration["DatabaseProvider"];
        if (providers.TryGetValue(selectedProvider, out Action addPersistenceServices))
        {
            addPersistenceServices();
            return;
        }

        throw new NotSupportedException($"Provider '{selectedProvider}' is not supported");
    }
}
