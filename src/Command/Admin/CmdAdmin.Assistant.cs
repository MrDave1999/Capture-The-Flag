using CaptureTheFlag.Data;
using CaptureTheFlag.Dialogs;
using CaptureTheFlag.Events;
using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Teams;
using CaptureTheFlag.Textdraw;
using CaptureTheFlag.Utils;
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
        private static void ChangeMap(Player player, string value = null)
        {
            if (player.IsAdminLevel(1)) return;
            var cm = new ListDialogEx("", "Seleccionar", "Cerrar");
            int nextmap = GetNextMapId();
            for (int i = 0; i < MAX_MAPS; ++i)
            {
                if (value == null || mapName[i].StartsWith(value, StringComparison.OrdinalIgnoreCase))
                {
                    cm.AddItem(i, mapName[i]);
                    if (i == Id)
                        cm.Items[^1] = $"{mapName[i]}{Color.Red} -> (MAPA ACTUAL)";
                    if (i == nextmap)
                        cm.Items[^1] = $"{mapName[i]}{Color.Green} -> (PRÓXIMO MAPA)";
                }
            }
            if(cm.Items.Count == 0)
            {
                player.SendClientMessage(Color.Red, "Error: No se encontraron coincidencias.");
                return;
            }
            cm.Caption = $"MAPS: {cm.Items.Count}/{MAX_MAPS}";
            cm.Show(player);
            cm.Response += (sender, e) =>
            {
                var itemId = cm.Ids[e.ListItem];
                if (e.DialogButton == DialogButton.Left)
                {
                    if (itemId == Id)
                    {
                        player.SendClientMessage(Color.Red, $"Error: {GetCurrentMap()} es el mapa actual (elige otro).");
                        cm.Show(player);
                        return;
                    }
                    var confirm = new MessageDialog("Confimación", "¿Deseas forzar el cambio de mapa ahora mismo?", "Si", "No");
                    confirm.Show(player);
                    confirm.Response += (sender, ex) => OnConfirmMapChange(itemId, ex);
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
            TeamAlpha.Timer.Stop();
            TeamBeta.Timer.Stop();
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
            if (player.Equals(player1, "No te puedes observar a ti mismo."))
                return;
            if (player.AFK)
            {
                player.SendClientMessage(Color.Red, "Error: Estás en AFK. Usa /outafk.");
                return;
            }
            if (player1.IsSelectionClass)
            {
                player.SendClientMessage(Color.Red, "Error: Ese jugador se encuentra en la selección de clases.");
                return;
            }
            if (player1.State == PlayerState.Spectating)
            {
                player.SendClientMessage(Color.Red, "Error: Ese jugador se encuentra en modo espectador.");
                return;
            }
            if (player.IsCapturedFlag())
                player.Drop();
            player.SetNoTeam();
            TextDrawGlobal.UpdateCountUsers();
            player.SendClientMessage(Color.Yellow, $"* Estás observando al usuario {player1.Name}");
            player.Interior = player1.Interior;
            player.VirtualWorld = player1.VirtualWorld;
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

        [Command("setallweather", Shortcut = "setallweather", UsageMessage = "/setallweather [weatherid]")]
        private static void SetAllWeather(Player player, int weatherid)
        {
            if (player.IsAdminLevel(1)) return;
            if(weatherid < 0 || weatherid > 255)
            {
                player.SendClientMessage(Color.Red, "Error: El ID del clima debe estar entre el rango de 0 a 255.");
                return;
            }
            Server.SetWeather(weatherid);
            SendMessageToAdmins(player, "setallweather");
        }

        [Command("setalltime", Shortcut = "setalltime", UsageMessage = "/setalltime [hour]")]
        private static void SetAllWorldTime(Player player, int hour)
        {
            if (player.IsAdminLevel(1)) return;
            Validate.IsHoursRange(player, hour);
            Server.SetWorldTime(hour);
            SendMessageToAdmins(player, "setalltime");
        }

        [Command("ac", Shortcut = "ac", UsageMessage = "/ac [message]")]
        public static void AdminChat(Player player, string msg)
        {
            if (player.IsAdminLevel(1)) return;
            SendMessageToAdmins($"[Admin Chat] {player.Name} [{player.Id}]: {msg}", 0x33FF33AA);
        }

        [Command("asay", Shortcut = "asay", UsageMessage = "/asay [message]")]
        public static void Asay(Player player, string msg)
        {
            if (player.IsAdminLevel(1)) return;
            BasePlayer.SendClientMessageToAll($"{Colors.GetColorAdmin(player.Data.LevelAdmin)}»|» {Rank.GetRankAdmin(player.Data.LevelAdmin)} «|« {player.Name}: {Color.White}{msg}");
        }
    }
}
