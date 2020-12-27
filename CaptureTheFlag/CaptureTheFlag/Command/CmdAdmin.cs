using CaptureTheFlag.Map;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.GameMode;
using static CaptureTheFlag.Map.CurrentMap;

namespace CaptureTheFlag.Command
{
    [CommandGroup("admin", PermissionChecker = typeof(BlockCommand))]
    public class CmdAdmin
    {
        [Command("changemap", Shortcut = "changemap")]
        private static void ChangeMap(Player player)
        {
            //if (player.IsAdminLevel(1)) return;
            var cm = new ListDialog($"Total Maps: {MAX_MAPS}", "Seleccionar", "Cerrar");
            foreach(string map in mapName)
                cm.AddItem(map);
            cm.Show(player);
            cm.Response += (sender, e) =>
            {
                if(e.DialogButton == DialogButton.Left)
                {
                    if(e.ListItem == Id)
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
        }

        [Command("resetflags", Shortcut = "resetflags")]
        private static void ResetFlags(Player player)
        {
            //if (player.IsAdminLevel(1)) return;
            Flag.RemoveAll();
            TeamAlpha.Flag.DeletePlayerCaptured();
            TeamBeta.Flag.DeletePlayerCaptured();
            TeamAlpha.Flag.Create();
            TeamBeta.Flag.Create();
            BasePlayer.SendClientMessageToAll(Color.Yellow, "* Las banderas fueron reseteadas a su posición inicial.");
        }

        [Command("benefit", Shortcut = "benefit", UsageMessage = "/benefit [playerid]")]
        private static void BenefitEnable(Player player, int playerid)
        {
            //if (player.IsAdminLevel(1)) return;
            Player player1 = Player.Find(player, playerid);
            player.SendClientMessage(Color.Orange, $"-> Name: {player1.Name} / ID: {player1.Id}");
            player.SendClientMessage(Color.Orange, $"-Jumps: {(player1.IsEnableJump() ? Time.Show(player1.JumpTime) : "No")}");
            player.SendClientMessage(Color.Orange, $"-Speed: {(player1.IsEnableSpeed() ? Time.Show(player1.SpeedTime) : "No")}");
        }
    }
}
