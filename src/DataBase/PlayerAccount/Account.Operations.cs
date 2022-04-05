 using CaptureTheFlag.PropertiesPlayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DbCommand;
using static CaptureTheFlag.DataBase.DbConnection;

namespace CaptureTheFlag.DataBase.PlayerAccount
{
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
}

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player
    {
        public void UpdateData<T>(string campus, T newvalue) 
            => DataBase.PlayerAccount.Account.Update(campus, newvalue, this);

        public void UpdateAdminLevel(int newvalue)
            => DataBase.PlayerAccount.Account.Update("levelAdmin", newvalue, this, "admins");

        public void UpdateVipLevel(int newvalue)
            => DataBase.PlayerAccount.Account.Update("levelVip", newvalue, this, "vips");

        public void UpdateSkin(int newvalue)
            => DataBase.PlayerAccount.Account.Update("skinid", newvalue, this, "vips");
    }
}
