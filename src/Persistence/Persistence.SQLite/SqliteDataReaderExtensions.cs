namespace Persistence.SQLite;

internal static class SqliteDataReaderExtensions
{
    public static string GetString(this SqliteDataReader reader, string name)
        => reader.GetString(reader.GetOrdinal(name));

    public static int GetInt32(this SqliteDataReader reader, string name)
        => reader.GetInt32(reader.GetOrdinal(name));

    public static DateTime GetDateTime(this SqliteDataReader reader, string name)
        => reader.GetDateTime(reader.GetOrdinal(name));
}
