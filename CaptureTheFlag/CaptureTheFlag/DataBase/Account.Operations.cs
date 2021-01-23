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
        public static void Update<T>(string campus, T newvalue, string nameplayer, string nametable = "Players")
        {
            cmd.CommandText = $"UPDATE {nametable} SET {campus}=@{campus} WHERE namePlayer = @name_player;";
            cmd.Parameters.AddWithValue("@" + campus, newvalue);
            cmd.Parameters.AddWithValue("@name_player", nameplayer);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertVipLevel(Player player, int levelid)
        {
            cmd.CommandText = "INSERT INTO Vips(namePlayer, levelVip, skinid) VALUES(@namePlayer, @levelid, -1);";
            cmd.Parameters.AddWithValue("@namePlayer", player.Name);
            cmd.Parameters.AddWithValue("@levelid", levelid);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertAdminLevel(Player player, int levelid)
        {
            cmd.CommandText = "INSERT INTO Admins(namePlayer, levelAdmin) VALUES(@namePlayer, @levelid);";
            cmd.Parameters.AddWithValue("@namePlayer", player.Name);
            cmd.Parameters.AddWithValue("@levelid", levelid);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void LoadVipLevel(Player player)
        {
            cmd.CommandText = "SELECT * FROM Vips WHERE namePlayer = @namePlayer;";
            cmd.Parameters.AddWithValue("@namePlayer", player.Name);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                player.Data.LevelVip = reader.GetInt32("levelVip");
                player.Data.SkinId = reader.GetInt32("skinid");
            }
            cmd.Parameters.Clear();
            reader.Close();
        }

        public static void LoadAdminLevel(Player player)
        {
            cmd.CommandText = "SELECT * FROM Admins WHERE namePlayer = @namePlayer;";
            cmd.Parameters.AddWithValue("@namePlayer", player.Name);
            var reader = cmd.ExecuteReader();
            if(reader.Read()) 
                player.Data.LevelAdmin = reader.GetInt32("levelAdmin");
            cmd.Parameters.Clear();
            reader.Close();
        }

        public static void DeleteLevel(Player player, string typelevel)
        {
            cmd.CommandText = $"DELETE FROM {typelevel} WHERE namePlayer = @namePlayer;";
            cmd.Parameters.AddWithValue("@namePlayer", player.Name);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
