﻿namespace CaptureTheFlag.DataBase.PlayerAccount;

public partial class Account
{
    public static void InsertVipLevel(Player player, int levelid)
    {
        using var con = CreateConnection();
        cmd.CommandText = $"INSERT INTO vips(accountNumber, levelVip, skinid) VALUES('{player.Data.AccountNumber}', {levelid}, -1);";
        cmd.ExecuteNonQuery();
    }

    public static void InsertAdminLevel(Player player, int levelid)
    {
        using var con = CreateConnection();
        cmd.CommandText = $"INSERT INTO admins(accountNumber, levelAdmin) VALUES('{player.Data.AccountNumber}', {levelid});";
        cmd.ExecuteNonQuery();
    }
}
