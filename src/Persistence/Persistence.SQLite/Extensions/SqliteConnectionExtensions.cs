namespace Persistence.SQLite.Extensions;

public static class SqliteConnectionExtensions
{
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/user-defined-functions#operators">
    /// See user-defined functions.
    /// </see>
    /// </summary>
    public static void CreateRegexpFunction(this SqliteConnection connection)
    {
        connection.CreateFunction(
            name: "regexp",
            function: (string pattern, string input) => Regex.IsMatch(input, pattern)
        );
    }
}
