using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Admin
{
    public partial class CmdAdmin
    {
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
