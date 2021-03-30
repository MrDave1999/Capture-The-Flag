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
        [Command("vip", Shortcut = "vip")]
        private static void UsageMessage(Player player)
        {
            player.SendClientMessage(Color.Red, "Usage: /vip [1-3]");
        }

        [Command("1")]
        private static void Cmds_Silver(Player player)
        {
            if (player.IsVipLevel(1)) return;
            new MessageDialog("Comandos - Silver (Nivel 1)",
                $"{Color.Yellow}/skin{Color.White} - Permite cambiar de skin." +
                $"\n{Color.Yellow}/sskin{Color.White} - Guarda el skin de forma automática." +
                $"\n{Color.Yellow}/rskin{Color.White} - Elimina el skin que hayas guardado." +
                $"\n{Color.Yellow}/saw{Color.White} - Permite obtener una motosierra." +
                $"\n{Color.Yellow}/spray{Color.White} - Permite obtener un spray." +
                $"\n{Color.Yellow}/weather{Color.White} - Permite cambiar de clima." +
                $"\n{Color.Yellow}/vsay{Color.White} - Te permite hablar como usuario VIP." +
                $"\n{Color.Yellow}/vc{Color.White} - Permite hablar en el VipChat." +
                $"\n\n{Color.Orange}También puedes hablar en el VIP Chat con el signo: {Color.White}$texto" +
                $"\n{Color.Orange}Puedes hablar como usuario VIP con el signo: {Color.White}@texto", "Aceptar", "").Show(player);
        }

        [Command("2")]
        private static void Cmds_Gold(Player player)
        {
            if (player.IsVipLevel(2)) return;
            new MessageDialog("Comandos - Gold (Nivel 2)",
                $"{Color.Yellow}/health{Color.White} - Te establece la salud al 100 %" +
                $"\n{Color.Yellow}/armour{Color.White} - Te establece la armadura al 100 %" +
                $"\n{Color.Yellow}/jumpon{Color.White} - Activa los saltos mortales." +
                $"\n{Color.Yellow}/jumpoff{Color.White} - Desactiva los saltos mortales." +
                $"\n{Color.Yellow}/p{Color.White} - Asigna un paracaidas." +
                $"\n{Color.Yellow}/nsay{Color.White} - Permite hablar como anónimo." +
                $"\n\n{Color.Orange}Puedes hablar como usuario anónimo con el signo: {Color.White}~texto", "Aceptar", "").Show(player);
        }

        [Command("3")]
        private static void Cmds_Premium(Player player)
        {
            if (player.IsVipLevel(3)) return;
            new MessageDialog("Comandos - Premium (Nivel 3)",
                $"{Color.Yellow}/invisible{Color.White} - Te permite ser invisible." +
                $"\n{Color.Yellow}/visible{Color.White} - Quita la invisibilidad." +
                $"\n{Color.Yellow}/flame{Color.White} - Permite obtener una lanzallamas." +
                $"\n{Color.Yellow}/clearchat{Color.White} - Borra el chat del jugador." + 
                $"\n\n{Color.Orange}* Cada vez que inicie una partida tendrás 100 % de adrenalina.", "Aceptar", "").Show(player);
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
