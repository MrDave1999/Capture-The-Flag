using CaptureTheFlag.PropertiesPlayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DbCommand;

namespace CaptureTheFlag.DataBase.PlayerAccount
{
    public partial class Account
    {
        public static void InsertVipLevel(Player player, int levelid)
        {
            cmd.CommandText = $"INSERT INTO vips(accountNumber, levelVip, skinid) VALUES('{player.Data.AccountNumber}', {levelid}, -1);";
            cmd.ExecuteNonQuery();
        }

        public static void InsertAdminLevel(Player player, int levelid)
        {
            cmd.CommandText = $"INSERT INTO admins(accountNumber, levelAdmin) VALUES('{player.Data.AccountNumber}', {levelid});";
            cmd.ExecuteNonQuery();
        }
    }
}
