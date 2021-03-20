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
        public static void InsertVipLevel(Player player, int levelid)
        {
            try
            {
                cmd.CommandText = $"INSERT INTO vips(accountNumber, levelVip, skinid) VALUES('{player.Data.AccountNumber}', {levelid}, -1);";
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }

        public static void InsertAdminLevel(Player player, int levelid)
        {
            try
            {
                cmd.CommandText = $"INSERT INTO admins(accountNumber, levelAdmin) VALUES('{player.Data.AccountNumber}', {levelid});";
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error {e.StackTrace} Reason: {e.Message}");
            }
        }
    }
}
