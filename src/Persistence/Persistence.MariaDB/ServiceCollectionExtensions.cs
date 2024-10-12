namespace Persistence.MariaDB;

public static class PersistenceMariaDBServicesExtensions
{
    public static IServiceCollection AddPersistenceMariaDBServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var mariadbSettings = configuration
            .GetRequiredSection("MariaDB")
            .Get<MariaDbSettings>();

        var connectionString = new MySqlConnectionStringBuilder()
        {
            Server   = mariadbSettings.Server,
            Port     = mariadbSettings.Port,
            Database = mariadbSettings.Database,
            UserID   = mariadbSettings.UserName,
            Password = mariadbSettings.Password
        }.ToString();

        mariadbSettings.ConnectionString = connectionString;
        services.AddSingleton(mariadbSettings);
        services.AddSingleton<IPlayerRepository, PlayerRepository>();

        var path = Path.Combine("yesql", typeof(PersistenceMariaDBServicesExtensions).Namespace);
        ISqlCollection sqlCollection = new YeSqlLoader().LoadFromDirectories(path);
        services.AddSingleton(sqlCollection);
        return services;
    }
}
