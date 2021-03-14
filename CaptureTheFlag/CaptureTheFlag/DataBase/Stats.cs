﻿using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.DBCommand;

namespace CaptureTheFlag.Command.Public
{
    public partial class CmdPublic
    {
        [Command("statsdb", Shortcut = "statsdb", UsageMessage = "/statsdb [playername]")]
        public static void StatsDb(Player player, string playername)
        {
            cmd.CommandText = $"SELECT * FROM players WHERE namePlayer = '{playername}';";
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var stats = new TablistDialog("Stats", 2, "Aceptar", "");
                var id = reader.GetInt32("accountNumber");
                stats.Add(new[] { "Name", reader.GetString("namePlayer") });
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
                stats.Show(player);
            }
            else
                player.SendClientMessage(Color.Red, "Error: Ese nombre no se encuentra en la base de datos del servidor.");
        }
    }
}