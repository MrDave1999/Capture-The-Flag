namespace CaptureTheFlag.DataBase.PlayerAccount;

public partial class Account
{
    public static void Update<T>(string campus, T newvalue, Player player, string tablename = "players")
    {
        using var con = CreateConnection();
        cmd.CommandText = $"UPDATE {tablename} SET {campus}='{newvalue}' WHERE accountNumber = '{player.Data.AccountNumber}';";
        cmd.ExecuteNonQuery();
    }

    public static void Delete(Player player, string tablename)
    {
        using var con = CreateConnection();
        cmd.CommandText = $"DELETE FROM {tablename} WHERE accountNumber = '{player.Data.AccountNumber}';";
        cmd.ExecuteNonQuery();
    }
}