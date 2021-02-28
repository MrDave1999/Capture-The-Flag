using CaptureTheFlag.PropertiesPlayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DBCommand;

namespace CaptureTheFlag.DataBase
{
    public partial class Account
    {
        public static void Update<T>(string campus, T newvalue, long accountNumber)
        {
            cmd.CommandText = $"UPDATE players SET {campus}=@{campus} WHERE accountNumber = @accountNumber;";
            cmd.Parameters.AddWithValue("@" + campus, newvalue);
            cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void Update<T>(string campus, T newvalue, string nameplayer, string nametable)
        {
            cmd.CommandText = $"UPDATE {nametable} SET {campus}=@{campus} WHERE namePlayer = @name_player;";
            cmd.Parameters.AddWithValue("@" + campus, newvalue);
            cmd.Parameters.AddWithValue("@name_player", nameplayer);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertVipLevel(Player player, int levelid)
        {
            cmd.CommandText = $"INSERT INTO vips(namePlayer, levelVip, skinid) VALUES('{player.Name}', {levelid}, -1);";
            cmd.ExecuteNonQuery();
        }

        public static void InsertAdminLevel(Player player, int levelid)
        {
            cmd.CommandText = $"INSERT INTO admins(namePlayer, levelAdmin) VALUES('{player.Name}', {levelid});";
            cmd.ExecuteNonQuery();
        }

        public static void LoadVipLevel(Player player)
        {
            cmd.CommandText = $"SELECT * FROM vips WHERE namePlayer = '{player.Name}';";
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                player.Data.LevelVip = reader.GetInt32("levelVip");
                player.Data.SkinId = reader .GetInt32("skinid");
            }
        }

        public static void LoadAdminLevel(Player player)
        {
            cmd.CommandText = $"SELECT * FROM admins WHERE namePlayer = '{player.Name}';";
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) 
                player.Data.LevelAdmin = reader.GetInt32("levelAdmin");
        }

        public static void DeleteLevel(Player player, string typelevel)
        {
            cmd.CommandText = $"DELETE FROM {typelevel} WHERE namePlayer = '{player.Name}';";
            cmd.ExecuteNonQuery();
        }
    }
}

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player
    {
        public void UpdateData<T>(string campus, T newvalue) 
            => DataBase.Account.Update(campus, newvalue, Data.AccountNumber);
    }
}
