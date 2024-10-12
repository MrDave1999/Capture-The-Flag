namespace Persistence.MariaDB;

internal class MariaDbSettings
{
    public string Server { get; set; }
    public uint Port { get; set; }
    public string Database { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConnectionString { get; set; }
}
