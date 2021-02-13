using CaptureTheFlag.Map;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.DataBase.Account;

namespace CaptureTheFlag.Command.Admin
{
    public partial class CmdAdmin
    {
        [Command("settimeleft", Shortcut = "settimeleft", UsageMessage = "/settimeleft [minutes]")]
        private static void SetTimeLeft(Player player, int minutes)
        {
            if (player.IsAdminLevel(4)) return;
            if(minutes < 0 || minutes > 60)
            {
                player.SendClientMessage(Color.Red, "Error: Los minutos deben estar en el rango de 0 a 60.");
                return;
            }
            CurrentMap.timeLeft = minutes * 60;
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} cambió el tiempo de la partida a {Color.Orange}{minutes} {(minutes == 1 ? "minuto" : "minutos")}.");
            SendMessageToAdmins(player, "settimeleft");
        }

        [Command("setlevel", Shortcut = "setlevel", UsageMessage = "/setlevel [playerid] [levelid]")]
        private static void SetLevel(Player player, int playerid, int levelid)
        {
            if (player.IsAdminLevel(4)) return;
            if (levelid < 0 || levelid > 4)
            {
                player.SendClientMessage(Color.Red, "Error: Ingresa un nivel válido [0/4].");
                return;
            }
            Player player1 = Player.Find(player, playerid);
            if(levelid == player1.Data.LevelAdmin)
            {
                player.SendClientMessage(Color.Red, "Error: Ese jugador ya tiene ese nivel.");
                return;
            }

            if (player1.Data.LevelAdmin == 0)
            {
                Player.Admins.Add(player1);
                InsertAdminLevel(player1, levelid);
            }
            else if (levelid == 0)
            {
                Player.Admins.Remove(player1);
                DeleteLevel(player1, "admins");
                player1.SendClientMessage(Color.Red, "* Ya no formas parte del STAFF.");
                player.SendClientMessage(Color.Yellow, $"* Le quitaste el rango a {player1.Name}");
            }
            else
                Update("levelAdmin", levelid, player1.Name, "admins");

            player1.GameText(levelid < player1.Data.LevelAdmin ? "demoted Admin" : "promoted Admin", 4000, 3);
            if (levelid != 0)
                BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} le dio el rango de {Rank.GetRankAdmin(levelid)} al jugador {player1.Name}");
            player1.Data.LevelAdmin = levelid;
            SendMessageToAdmins(player, "setlevel");
        }

        [Command("setvip", Shortcut = "setvip", UsageMessage = "/setvip [playerid] [levelid]")]
        private static void SetVip(Player player, int playerid, int levelid)
        {
            if (player.IsAdminLevel(4)) return;
            if (levelid < 0 || levelid > 3)
            {
                player.SendClientMessage(Color.Red, "Error: Ingresa un nivel válido [0/3].");
                return;
            }
            Player player1 = Player.Find(player, playerid);
            if (levelid == player1.Data.LevelVip)
            {
                player.SendClientMessage(Color.Red, "Error: Ese jugador ya tiene ese nivel.");
                return;
            }

            if (player1.Data.LevelVip == 0)
            {
                Player.Vips.Add(player1);
                InsertVipLevel(player1, levelid);
            }
            else if (levelid == 0)
            {
                Player.Vips.Remove(player1);
                DeleteLevel(player1, "vips");
                player1.SendClientMessage(Color.Red, "* Ya no eres usuario VIP.");
                player.SendClientMessage(Color.Yellow, $"* Le quitaste el rango VIP a {player1.Name}");
            }
            else
                Update("levelVip", levelid, player1.Name, "vips");

            player1.GameText(levelid < player1.Data.LevelVip ? "demoted VIP" : "promoted VIP", 4000, 3);
            if(levelid != 0)
                BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} le dio el rango de {Rank.GetRankVip(levelid)} al jugador {player1.Name}");
            player1.Data.LevelVip = levelid;
            SendMessageToAdmins(player, "setvip");
        }

        [Command("lockserver", Shortcut = "lockserver", UsageMessage = "/lockserver [password]")]
        private static void LockServer(Player player, string password)
        {
            if (player.IsAdminLevel(4)) return;
            Server.SendRconCommand($"password {password}");
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} le puso contraseña al servidor. Ahora nadie podrá entrar.");
            SendMessageToAdmins(player, "lockserver");
        }

        [Command("unlockserver", Shortcut = "unlockserver")]
        private static void UnLockServer(Player player)
        {
            if (player.IsAdminLevel(4)) return;
            Server.SendRconCommand("password 0");
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} le quito la contraseña al servidor. Ahora la gente sí podrá entrar.");
            SendMessageToAdmins(player, "unlockserver");
        }

        [Command("restartserver", Shortcut = "restartserver")]
        private static void RestartServer(Player player)
        {
            if (player.IsAdminLevel(4)) return;
            BasePlayer.SendClientMessageToAll(Color.Yellow, "[Anuncio]: El servidor se reiniciará en 5 segundos.");
            new Timer(5000, false).Tick += (sender, e) =>
            {
                Server.SendRconCommand("gmx");
            };
            SendMessageToAdmins(player, "restartserver");
        }
    }
}
