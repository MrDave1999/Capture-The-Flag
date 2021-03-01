using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CaptureTheFlag.Command.Admin
{
    public partial class CmdAdmin
    {
        [Command("banips", Shortcut = "banips")]
        private static void BanIps(Player player)
        {
            if (player.IsAdminLevel(3)) return;
            string[] lists = File.ReadAllLines("./samp.ban");
            var dialog = new ListDialog("Ban IPs", "Cerrar", "");
            foreach(string info in lists)
                dialog.AddItem(info);
            dialog.Show(player);
        }

        [Command("setadre", Shortcut = "setadre", UsageMessage = "/setadre [playerid] [adrenaline]")]
        private static void SetAdrenaline(Player player, int playerid, int adrenaline)
        {
            if (player.IsAdminLevel(3)) return;
            if(adrenaline < 0 || adrenaline > 100)
            {
                player.SendClientMessage(Color.Red, "Error: La adrenalina debe estar entre el rango de 0 a 100.");
                return;
            }
            Player player1 = Player.Find(player, playerid);
            player1.Adrenaline = adrenaline;
            TextDrawPlayer.UpdateTdStats(player1);
            player.SendClientMessage(Color.Yellow, $"* Le diste al jugador {player1.Name} {adrenaline}%% de adrenalina.");
            player1.SendClientMessage(Color.Yellow, $"* {player.Name} te estableció la adrenalina a {adrenaline}%%.");
            SendMessageToAdmins(player, "setadre");
        }

        [Command("setkills", Shortcut = "setkills", UsageMessage = "/setkills [playerid] [kills]")]
        private static void SetKills(Player player, int playerid, int kills)
        {
            if (player.IsAdminLevel(3)) return;
            if(kills < 0)
            {
                player.SendClientMessage(Color.Red, "Error: Los kills no pueden ser negativo.");
                return;
            }
            Player player1 = Player.Find(player, playerid);
            player1.Kills = kills;
            TextDrawPlayer.UpdateTdStats(player1);
            player.SendClientMessage(Color.Yellow, $"* Le diste al jugador {player1.Name} {kills} kills.");
            player1.SendClientMessage(Color.Yellow, $"* {player.Name} te estableció los kills a {kills}.");
            SendMessageToAdmins(player, "setkills");
        }

        [Command("goto", Shortcut = "goto", UsageMessage = "/goto [playerid]")]
        private static void Goto(Player player, int playerid)
        {
            if (player.IsAdminLevel(3)) return;
            Player player1 = Player.Find(player, playerid);
            if (player.Equals(player1, "No te puedes teletransportar a ti mismo.")) return;
            player.Position = new Vector3(player1.Position.X, player1.Position.Y, player1.Position.Z);
            SendMessageToAdmins(player, "goto");
        }

        [Command("get", Shortcut = "get", UsageMessage = "/get [playerid]")]
        private static void GetPos(Player player, int playerid)
        {
            if (player.IsAdminLevel(3)) return;
            Player player1 = Player.Find(player, playerid);
            if (player.Equals(player1, "No te puedes traer a ti mismo.")) return;
            player1.Position = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
            SendMessageToAdmins(player, "get");
        }

        [Command("banip", Shortcut = "banip", UsageMessage = "/banip [playerid] [reason]")]
        private static void Ban(Player player, int playerid, string reason)
        {
            if (player.IsAdminLevel(3)) return;
            Player player1 = Player.Find(player, playerid);
            if (player.Equals(player1, "No te puedes banear a ti mismo.")) return;
            BasePlayer.SendClientMessageToAll(Color.Red, $"* {player.Name} ha prohibido (ban) al usuario {player1.Name} [Razón: {reason}].");
            SendMessageToAdmins(player, "banip");
            player1.Ban(reason);
        }

        [Command("unbanip", Shortcut = "unbanip", UsageMessage = "/unbanip [ip]")]
        private static void UnBan(Player player, string ip)
        {
            if (player.IsAdminLevel(3)) return;
            player.SendClientMessage(Color.Yellow, $"* Has desbaneado la IP: {ip}");
            Server.SendRconCommand($"unbanip {ip}");
            SendMessageToAdmins(player, "unbanip");
        }
    }
}
