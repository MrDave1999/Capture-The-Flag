using CaptureTheFlag.Events;
using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.Events.GameMode;
using static CaptureTheFlag.Map.CurrentMap;

namespace CaptureTheFlag.Command.Admin
{
    public partial class CmdAdmin
    {
        [Command("changemap", Shortcut = "changemap")]
        private static void ChangeMap(Player player)
        {
            if (player.IsAdminLevel(1)) return;
            var cm = new ListDialog($"Total Maps: {MAX_MAPS}", "Seleccionar", "Cerrar");
            foreach (string map in mapName)
                cm.AddItem(map);
            cm.Show(player);
            cm.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    if (e.ListItem == Id)
                    {
                        player.SendClientMessage(Color.Red, $"Error: {GetCurrentMap()} es el mapa actual (elige otro).");
                        cm.Show(player);
                        return;
                    }
                    ForceMap = e.ListItem;
                    timeLeft = 5;
                    BasePlayer.SendClientMessageToAll(Color.Red, $"[Change Map]: {Color.Yellow}{player.Name} Forzó el cambio de mapa a: {Color.Red}{GetMapName(e.ListItem)}.");
                }
            };
            SendMessageToAdmins(player, "changemap");
        }

        [Command("resetflags", Shortcut = "resetflags")]
        private static void ResetFlags(Player player)
        {
            if (player.IsAdminLevel(1)) return;
            Flag.RemoveAll();
            TeamAlpha.Flag.DeletePlayerCaptured();
            TeamBeta.Flag.DeletePlayerCaptured();
            TeamAlpha.Flag.Create();
            TeamBeta.Flag.Create();
            BasePlayer.SendClientMessageToAll(Color.Yellow, "* Las banderas fueron reseteadas a su posición inicial.");
            SendMessageToAdmins(player, "resetflags");
        }

        [Command("benefit", Shortcut = "benefit", UsageMessage = "/benefit [playerid]")]
        private static void BenefitEnable(Player player, int playerid)
        {
            if (player.IsAdminLevel(1)) return;
            Player player1 = Player.Find(player, playerid);
            player.SendClientMessage(Color.Orange, $"-> Name: {player1.Name} / ID: {player1.Id}");
            player.SendClientMessage(Color.Orange, $"-Jumps: {(player1.IsEnableJump() ? Time.Show(player1.JumpTime) : "No")}");
            player.SendClientMessage(Color.Orange, $"-Speed: {(player1.IsEnableSpeed() ? Time.Show(player1.SpeedTime) : "No")}");
            player.SendClientMessage(Color.Orange, $"-Invisibility: {(player1.IsEnableInvisible() ? Time.Show(player1.InvisibleTime) : "No")}");
            SendMessageToAdmins(player, "benefit");
        }

        [Command("ip", Shortcut = "ip", UsageMessage = "/ip [playerid]")]
        private static void IP(Player player, int playerid)
        {
            if (player.IsAdminLevel(1)) return;
            Player player1 = Player.Find(player, playerid);
            player.SendClientMessage(Color.Yellow, $"* La IP del usuario {player1.Name} es: {player1.IP}");
            SendMessageToAdmins(player, "ip");
        }

        [Command("spec", Shortcut = "spec", UsageMessage = "/spec [playerid]")]
        private static void Spec(Player player, int playerid)
        {
            if (player.IsAdminLevel(1)) return;
            Player player1 = Player.Find(player, playerid);
            if (player.Equals(player1, "No te puedes observar a ti mismo.")) return;
            if (player.IsCapturedFlag())
                player.Drop();
            player.SetNoTeam();
            TextDrawGlobal.UpdateCountUsers();
            player.SendClientMessage(Color.Yellow, $"* Estás observando al usuario {player1.Name}");
            player.ToggleSpectating(true);
            player.SpectatePlayer(player1);
            SendMessageToAdmins(player, "spec");
        }

        [Command("specoff", Shortcut = "specoff", UsageMessage = "/specoff")]
        private static void Specoff(Player player)
        {
            if (player.IsAdminLevel(1)) return;
            if (player.State == PlayerState.Spectating)
            {
                player.SendClientMessage(Color.Yellow, $"* Dejaste de observar al usuario.");
                player.SetForceClass();
                SendMessageToAdmins(player, "specoff");
            }
            else
                player.SendClientMessage(Color.Red, "Error: No estás observando a nadie.");
        }

        [Command("slap", Shortcut = "slap", UsageMessage = "/slap [playerid]")]
        private static void Slap(Player player, int playerid)
        {
            if (player.IsAdminLevel(1)) return;
            Player player1 = Player.Find(player, playerid);
            player.SendClientMessage(Color.Yellow, $"* Le pegaste al jugador: {player1.Name}");
            player1.Position = new Vector3(player1.Position.X, player1.Position.Y, player1.Position.Z + 5.0);
            SendMessageToAdmins(player, "slap");
        }

        [Command("warn", Shortcut = "warn", UsageMessage = "/warn [playerid] [reason]")]
        private static void Warn(Player player, int playerid, string reason)
        {
            if (player.IsAdminLevel(1)) return;
            Player player1 = Player.Find(player, playerid);
            if (player.Equals(player1, "No te puedes dar una advertencia a ti mismo.")) return;
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} le dio una advertencia a {player1.Name} [{++player1.Warns}/3] [Razón: {reason}].");
            if (player1.Warns == 3)
                player1.Kick();
            SendMessageToAdmins(player, "warn");
        }

        [Command("setworld", Shortcut = "setworld", UsageMessage = "/setworld [playerid] [worldid]")]
        private static void SetWorld(Player player, int playerid, int worldid)
        {
            if (player.IsAdminLevel(1)) return;
            Player player1 = Player.Find(player, playerid);
            player.SendClientMessage(Color.Yellow, $"* Mandaste al jugador: {player1.Name} al mundo virtual #{worldid}");
            player1.VirtualWorld = worldid;
            SendMessageToAdmins(player, "setworld");
        }

        [Command("ac", Shortcut = "ac", UsageMessage = "/ac [message]")]
        public static void AdminChat(Player player, string msg)
        {
            if (player.IsAdminLevel(1)) return;
            SendMessageToAdmins($"[Admin Chat] {player.Name} [{player.Id}]: {msg}", 0x33FF33AA);
        }

        [Command("say", Shortcut = "say", UsageMessage = "/say [message]")]
        private static void Say(Player player, string msg)
        {
            if (player.IsAdminLevel(1)) return;
            BasePlayer.SendClientMessageToAll($"{colours[player.Data.LevelAdmin - 1]}..:: {Rank.GetRankAdmin(player.Data.LevelAdmin)} ::.. {player.Name}: {Color.White}{msg}");
        }

        private static string[] colours = new[]
        {
            "{FFFF00}", //yellow
            "{00FFFF}", //cian
            "{FF0000}", //red
            "{FF00FF}", //magenta
        };
    }
}
