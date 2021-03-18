using CaptureTheFlag.DataBase;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static CaptureTheFlag.Events.GameMode;

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
                $"\n{Color.Yellow}Account Number: {Color.White}{player1.Data.AccountNumber}" +
                $"\n{Color.Yellow}Registry Date: {Color.White}{ParseData.ToStringDateTime(player1.Data.RegistryDate)}" +
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

        [Command("changepass", Shortcut = "changepass")]
        public static void ChangePassword(Player player)
        {
            if (player.IsGameLevel(2)) return;
            var dialogPass = new InputDialog("Password New", "Ingrese su nueva contraseña:", true, "Aceptar", "Cerrar");
            dialogPass.Show(player);
            dialogPass.Response += (sender, e) =>
            {
                if(e.DialogButton == DialogButton.Left)
                {
                    Validate.IsEmpty(player, dialogPass, e.InputText);
                    Validate.IsPasswordRange(player, dialogPass, e.InputText);
                    player.UpdateData("pass", Account.Encrypt(e.InputText));
                    player.SendClientMessage(Color.Orange, $"** La nueva contraseña de tu cuenta es: {e.InputText}");
                }
            };
        }

        [Command("changename", Shortcut = "changename", UsageMessage = "/changename [name]")]
        public static void ChangeName(Player player, string newname)
        {
            if (player.IsGameLevel(2)) return;
            if (!Validate.IsNameRange(player, newname)) return;
            if (!Validate.IsValidName(player, newname)) return;
            if (Account.Exists(newname))
            {
                player.SendClientMessage(Color.Red, "Error: Ese nombre ya existe en la base de datos.");
                return;
            }
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"[Anuncio]: {Color.Orange}{player.Name} cambió su nombre a {newname}");
            player.UpdateData("namePlayer", newname);
            player.Name = newname;
        }
    }
}
