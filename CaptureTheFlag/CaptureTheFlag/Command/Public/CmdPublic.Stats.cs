using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.GameMode;

namespace CaptureTheFlag.Command.Public
{
    public partial class CmdPublic
    {
        [Command("stats", Shortcut = "stats")]
        public static void StatsPlayer(Player player, int playerid = -1)
        {
            Player player1 = (playerid != -1 ? Player.Find(player, playerid) : player);
            var level = player1.Data.LevelGame;
            new MessageDialog($"Name: {player1.Name}",
                $"{Color.Yellow}ID: {Color.White}{player1.Id}" +
                $"\n{Color.Yellow}Registry Date: {Color.White}{player1.Data.RegistryDate}" +
                $"\n{Color.Yellow}Kills for Round: {Color.White}{player1.Kills}" +
                $"\n{Color.Yellow}Deaths for Round: {Color.White}{player1.Deaths}" +
                $"\n{Color.Yellow}Total Kills: {Color.White}{player1.Data.TotalKills}" +
                $"\n{Color.Yellow}Total Deaths: {Color.White}{player1.Data.TotalDeaths}" +
                $"\n{Color.Yellow}Admin Level: {Color.White}{player1.Data.LevelAdmin}" +
                $"\n{Color.Yellow}VIP Level: {Color.White}{player1.Data.LevelVip}" +
                $"\n{Color.Yellow}Rank: {Color.White}{Rank.GetRankLevel(level)}" +
                $"\n{Color.Yellow}Level: {Color.White}{player1.Data.LevelGame}" +
                $"\n{Color.Yellow}Next Rank: {Color.White}{Rank.GetNextRankLevel(level)}" +
                $"\n{Color.Yellow}DroppedFlags: {Color.White}{player1.Data.DroppedFlags}" +
                $"\n{Color.Yellow}Killing Sprees: {Color.White}{player1.Data.KillingSprees}" +
                $"\n{Color.Yellow}Headshots: {Color.White}{player1.Data.Headshots}" +
            $"\n{Color.Yellow}Adrenaline: {Color.White}{player1.Adrenaline}/100", "Cerrar", "").Show(player);
        }

        [Command("tstats", Shortcut = "tstats")]
        private static void StatsTeam(Player player)
        {
            new MessageDialog("Stats Team",
                TeamAlpha.OtherColor +
                "Team: Alpha" +
                "\nColor Team: Red" +
                "\nUsers: " + TeamAlpha.Members +
                "\nScore: " + TeamAlpha.Score +
                "\nTotal Kills: " + TeamAlpha.Kills +
                "\nTotal Deaths: " + TeamAlpha.Deaths +
                "\nCaptured Flag by: " + (TeamAlpha.Flag.PlayerCaptured == null ? "None" : $"{TeamAlpha.Flag.PlayerCaptured.Name}") +
                TeamBeta.OtherColor +
                "\n\nTeam: Beta" +
                "\nColor Team: Blue" +
                "\nUsers: " + TeamBeta.Members +
                "\nScore: " + TeamBeta.Score +
                "\nTotal Kills: " + TeamBeta.Kills +
                "\nTotal Deaths: " + TeamBeta.Deaths +
                "\nCaptured Flag by: " + (TeamBeta.Flag.PlayerCaptured == null ? "None" : $"{TeamBeta.Flag.PlayerCaptured.Name}"), "Aceptar").Show(player);
        }
    }
}
