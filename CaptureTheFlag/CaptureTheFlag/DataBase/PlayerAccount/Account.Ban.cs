using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Utils;
using MySql.Data.MySqlClient;
using SampSharp.GameMode.Display;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DbCommand;

namespace CaptureTheFlag.DataBase.PlayerAccount
{
    public partial class Account
    {
        public static DateTime? IsBanned(Player player)
        {
            cmd.CommandText = $"SELECT expiryDate FROM banned_players WHERE bannedPlayer = '{player.Name}';";
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return reader.GetDateTime("expiryDate");
            return null;
        }

        public static DateTime? InsertBan(Player bannedPlayer, Player adminPlayer, string reason, int days, int hours, int minutes, int seconds)
        {
            var startDate = DateTime.Now;
            var result = startDate + new TimeSpan(days, 0, 0, 0);
            var expiryDate = new DateTime(result.Year, result.Month, result.Day, hours, minutes, seconds);
            cmd.CommandText = $"INSERT INTO banned_players(accountNumber, bannedPlayer, adminPlayer, startDate, expiryDate, reason) VALUES({bannedPlayer.Data.AccountNumber}, '{bannedPlayer.Name}', '{adminPlayer.Name}', @startDate, @expiryDate, @reason);";
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@expiryDate", expiryDate);
            cmd.Parameters.AddWithValue("@reason", reason);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return expiryDate;
        }

        public static int DeleteBan(string name)
        {
            cmd.CommandText = $"DELETE FROM banned_players WHERE bannedPlayer = '{name}';";
            return cmd.ExecuteNonQuery();
        }

        public static bool ShowBans(Player player)
        {
            long rows = 0;
            cmd.CommandText = $"SELECT * FROM banned_players;";
            using var reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                var dialog = new TablistDialog($" ", new[] { "Name", "Start Date", "Expiry Date", "Days Left" }, "Cerrar");
                while (reader.Read())
                {
                    var expiryDate = reader.GetDateTime("expiryDate");
                    var diff = (expiryDate.Date - DateTime.Now.Date).Days;
                    dialog.Add(
                        new[]
                        {
                            reader.GetString("bannedPlayer"),
                            ParseData.ToStringDateTime(reader.GetDateTime("startDate")),
                            ParseData.ToStringDateTime(expiryDate),
                            (diff <= 0 ? "0" : diff.ToString())
                        }
                    );
                    ++rows;
                }
                dialog.Caption = $"Banned Accounts: {rows}";
                dialog.Show(player);
                return true;
            }
            return false;
        }
    }
}
