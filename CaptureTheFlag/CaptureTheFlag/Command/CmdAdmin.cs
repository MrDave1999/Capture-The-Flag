using CaptureTheFlag.Map;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command
{
    [CommandGroup("admin", PermissionChecker = typeof(BlockCommand))]
    public class CmdAdmin
    {
        [Command("changemap", Shortcut = "changemap")]
        private static void ChangeMap(Player player)
        {
            var cm = new ListDialog("Change Map", "Seleccionar", "Cerrar");
            foreach(string map in CurrentMap.mapName)
                cm.AddItem(map);
            cm.Show(player);
            cm.Response += (sender, e) =>
            {
                if(e.DialogButton == DialogButton.Left)
                {
                    if(e.ListItem == CurrentMap.Id)
                    {
                        player.SendClientMessage(Color.Red, $"Error: {CurrentMap.GetCurrentMap()} es el mapa actual (elige otro).");
                        cm.Show(player);
                        return;
                    }
                    CurrentMap.ForceMap = e.ListItem;
                    CurrentMap.timeLeft = 5;
                    BasePlayer.SendClientMessageToAll(Color.Red, $"[Change Map]: {Color.Yellow}{player.Name} Forzó el cambio de mapa a: {Color.Red}{CurrentMap.GetMapName(e.ListItem)}.");
                }
            };
        }
    }
}
