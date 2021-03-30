using CaptureTheFlag.DataBase;
using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Textdraw;
using MySql.Data.MySqlClient;
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

        [Command("nameban", Shortcut = "nameban", UsageMessage = "/nameban [playerid] [days] [hours] [minutes] [seconds] [reason]")]
        private static void NameBan(Player player, int playerid, int days, int hours, int minutes, int seconds, string reason)
        {
            if (player.IsAdminLevel(3)) return;
            Player player1 = Player.Find(player, playerid);
            if (days < 1 || days > 365)
            {
                player.SendClientMessage(Color.Red, "Error: Los días deben estar entre 1 a 365 días.");
                return;
            }
            if(hours < 0 || hours > 23)
            {
                player.SendClientMessage(Color.Red, "Error: Las horas deben estar entre 0 a 23 horas.");
                return;
            }
            if(minutes < 0 || minutes > 59)
            {
                player.SendClientMessage(Color.Red, "Error: Los minutos deben estar entre 0 a 59 minutos.");
                return;
            }
            if(seconds < 0 || seconds > 59)
            {
                player.SendClientMessage(Color.Red, "Error: Los segundos deben estar entre 0 a 59 segundos.");
                return;
            }
            if (reason.Length > 50)
            {
                player.SendClientMessage(Color.Red, "Error: La razón no puede tener mas de 50 caracteres.");
                return;
            }
            try
            {
                var expiryDate = Account.InsertBan(player1, player, reason, days, hours, minutes, seconds);
                BasePlayer.SendClientMessageToAll(Color.Red, $"* {player.Name} ha prohíbido la cuenta de {player1.Name} por {days} {(days == 1 ? "día" : "días")} [Razón: {reason}].");
                player1.SendClientMessage(Color.Red, $"* Tu cuenta quedará desbloqueada en esta fecha y hora: {ParseData.ToStringDateTime((DateTime)expiryDate)}.");
                player1.Kick();
                SendMessageToAdmins(player, "nameban");
            }
            catch(MySqlException e)
            {
                player.SendErrorMessage(e);
            }
        }

        [Command("dnameban", Shortcut = "dnameban", UsageMessage = "/dnameban [name]")]
        private static void DeleteNameBan(Player player, string name)
        {
            if (player.IsAdminLevel(3)) return;
            if (!Validate.IsNameRange(player, name)) return;
            if (!Validate.IsValidName(player, name)) return;
            try
            {
                if (Account.DeleteBan(name) == 0)
                {
                    player.SendClientMessage(Color.Red, "Error: La cuenta de ese jugador no tiene ninguna prohibición.");
                    return;
                }
                player.SendClientMessage(Color.Yellow, $"* Has desbloqueado la cuenta de {name}.");
                SendMessageToAdmins(player, "dnameban");
            }
            catch(MySqlException e)
            {
                player.SendErrorMessage(e);
            }
        }

        [Command("namebans", Shortcut = "namebans")]
        private static void NameBans(Player player)
        {
            if (player.IsAdminLevel(3)) return;
            try
            {
                if(!Account.ShowBans(player))
                {
                    player.SendClientMessage(Color.Red, "Error: No existe ningún nombre prohíbido en la base de datos.");
                    return;
                }
                SendMessageToAdmins(player, "namebans");
            }
            catch (MySqlException e)
            {
                player.SendErrorMessage(e);
            }
        }

        [Command("banip", Shortcut = "banip", UsageMessage = "/banip [playerid] [reason]")]
        private static void Ban(Player player, int playerid, string reason)
        {
            if (player.IsAdminLevel(3)) return;
            if(reason.Length > 50)
            {
                player.SendClientMessage(Color.Red, "Error: La razón no puede tener mas de 50 caracteres.");
                return;
            }
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

        [Command("banips", Shortcut = "banips")]
        private static void BanIps(Player player)
        {
            if (player.IsAdminLevel(3)) return;
            try
            {
                var lists = File.ReadAllLines("./samp.ban");
                if (lists.Length == 0)
                {
                    player.SendClientMessage(Color.Red, "Error: No se encontró ninguna IP prohíbida.");
                    return;
                }
                var dialog = new ListDialog($"Ban IPs: ({lists.Length})", "Cerrar", "");
                foreach (string info in lists)
                    dialog.AddItem(info);
                dialog.Show(player);
                SendMessageToAdmins(player, "banips");
            }
            catch (FileNotFoundException)
            {
                player.SendClientMessage(Color.Red, "Error: No se encontró ninguna IP prohíbida.");
            }
        }
    }
}
