using CaptureTheFlag.PropertiesPlayer;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DBCommand;

namespace CaptureTheFlag.DataBase
{
    public partial class Account
    {
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
                player.Data.SkinId = reader.GetInt32("skinid");
            }
        }

        public static void LoadAdminLevel(Player player)
        {
            cmd.CommandText = $"SELECT * FROM admins WHERE namePlayer = '{player.Name}';";
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                player.Data.LevelAdmin = reader.GetInt32("levelAdmin");
        }
    }
}
