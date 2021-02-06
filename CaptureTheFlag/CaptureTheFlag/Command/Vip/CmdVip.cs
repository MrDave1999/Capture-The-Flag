using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Vip
{
    [CommandGroup("vip", PermissionChecker = typeof(BlockCommand))]
    public partial class CmdVip
    {
        [Command("1")]
        private static void Cmds_Silver(Player player)
        {
            if (player.IsVipLevel(1)) return;
            new MessageDialog("Comandos - Silver (Nivel 1)",
                $"{Color.White}/skin, /sskin, /rskin, /saw, /spray, /weather, /vc",
                "Aceptar", "").Show(player);
        }

        [Command("2")]
        private static void Cmds_Gold(Player player)
        {
            if (player.IsVipLevel(2)) return;
            new MessageDialog("Comandos - Gold (Nivel 2)",
                $"{Color.White}/health, /armour, /jumpon, /jumpoff, /p, /nsay",
                "Aceptar", "").Show(player);
        }

        [Command("3")]
        private static void Cmds_Premium(Player player)
        {
            if (player.IsVipLevel(2)) return;
            new MessageDialog("Comandos - Premium (Nivel 3)",
                $"{Color.White}/invisible, /visible, /flame, /clearchat" +
                $"\n{Color.Yellow}* Cada vez que inicie una partida tendrás 100 % de adrenalina.",
                "Aceptar", "").Show(player);
        }

        [Command("vips", Shortcut = "vips")]
        private static void ListVips(Player player)
        {
            if (Player.Vips.Count == 0)
            {
                player.SendClientMessage(Color.Red, "Error: No hay usuarios VIPs conectados.");
                return;
            }
            var vips = new TablistDialog($"Vips: {Player.Vips.Count}", new[] { "Name", "Level", "Rank" }, "Aceptar", "");
            Player.Vips.Sort((a, b) => b.Data.LevelVip - a.Data.LevelVip);
            foreach (Player player1 in Player.Vips)
                vips.Add(new[] { player1.Name, player1.Data.LevelVip.ToString(), Rank.GetRankVip(player1.Data.LevelVip) });
            vips.Show(player);
        }

    }
}
