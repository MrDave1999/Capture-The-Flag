using CaptureTheFlag.PropertiesPlayer;
using MySql.Data.MySqlClient;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DBCommand;

namespace CaptureTheFlag.DataBase
{
    public class Stats
    {
        public static void ShowStatsDb(Player player, string playername)
        {
            try
            {
                cmd.CommandText = $"call getPlayerInfo('{playername}');";
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var stats = new TablistDialog("Stats", 2, "Aceptar", "");
                    var id = reader.GetInt32("accountNumber");
                    var skinid = reader.GetInt32("skinid");
                    stats.Add(new[] { "Name", reader.GetString("name") });
                    stats.Add(new[] { "Account Number", id.ToString() });
                    stats.Add(new[] { "Registry Date", ParseData.ToStringDateTime(reader.GetDateTime("registryDate")) });
                    stats.Add(new[] { "Last Connection",
                    !Player.IsPlayerOnline(id) ? ParseData.ToStringDateTime(reader.GetDateTime("lastConnection")) : "Connected" });
                    stats.Add(new[] { "Total Kills", reader.GetInt32("totalKills").ToString() });
                    stats.Add(new[] { "Total Deaths", reader.GetInt32("totalDeaths").ToString() });
                    stats.Add(new[] { "Killing Sprees", reader.GetInt32("killingSprees").ToString() });
                    int level = reader.GetInt32("levelGame");
                    stats.Add(new[] { "Game Level", level.ToString() });
                    stats.Add(new[] { "Rank", Rank.GetRankLevel(level) });
                    stats.Add(new[] { "Next Rank", Rank.GetNextRankLevel(level) });
                    stats.Add(new[] { "Dropped Flags", reader.GetInt32("droppedFlags").ToString() });
                    stats.Add(new[] { "Headshots", reader.GetInt32("headshots").ToString() });
                    stats.Add(new[] { "Admin Level", reader.GetInt32("levelAdmin").ToString() });
                    stats.Add(new[] { "VIP Level", reader.GetInt32("levelVip").ToString() });
                    stats.Add(new[] { "Saved Skin", skinid == -1 ? "None" : skinid.ToString() });
                    stats.Show(player);
                }
                else
                    player.SendClientMessage(Color.Red, "Error: Ese nombre no se encuentra en la base de datos del servidor.");
            }
            catch (MySqlException e)
            {
                player.SendErrorMessage(e);
            }
        }
    }
}
