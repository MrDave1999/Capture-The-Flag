using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.Command.Admin
{
    [CommandGroup("admin", PermissionChecker = typeof(BlockCommand))]
    public partial class CmdAdmin
    {
        [Command("1")]
        private static void Cmds_Assistant(Player player)
        {
            if (player.IsAdminLevel(1)) return;
            new MessageDialog("Comandos - Ayudante (Nivel 1)",
                $"{Color.White}/changemap, /resetflags, /ip, /spec, /specoff" +
                "\n/warn, /slap, /setworld, /ac, /benefit, /say", 
                "Aceptar", "").Show(player);
        }

        [Command("2")]
        private static void Cmds_Moderator(Player player)
        {
            if (player.IsAdminLevel(2)) return;
            new MessageDialog("Comandos - Moderador (Nivel 2)",
                $"{Color.White}/spawn, /kick, /announce, /announce2, /mute" +
                "\n/unmute, /clearallchat, /freeze, /unfreeze" +
                "\n/healall, /armourall, /explode",
                "Aceptar", "").Show(player);
        }

        [Command("3")]
        private static void Cmds_Administrator(Player player)
        {
            if (player.IsAdminLevel(3)) return;
            new MessageDialog("Comandos - Admin (Nivel 3)",
                $"{Color.White}/goto, /get, /banip, /unbanip, /setkills, /setadre",
                "Aceptar", "").Show(player);
        }

        [Command("4")]
        private static void Cmds_Owner(Player player)
        {
            if (player.IsAdminLevel(4)) return;
            new MessageDialog("Comandos - Dueño (Nivel 4)",
                $"{Color.White}/setlevel, /setvip, /lockserver, /unlockserver, /restartserver",
                "Aceptar", "").Show(player);
        }

        [Command("admins", Shortcut = "admins")]
        private static void ListAdmins(Player player)
        {
            if(Player.Admins.Count == 0)
            {
                player.SendClientMessage(Color.Red, "Error: No hay administradores conectados.");
                return;
            }
            var admins = new TablistDialog($"Admins: {Player.Admins.Count}", new[] {"Name", "Level", "Rank"}, "Aceptar", "");
            Player.Admins.Sort((a, b) => b.Data.LevelAdmin - a.Data.LevelAdmin);
            foreach (Player player1 in Player.Admins)
                admins.Add(new[] { player1.Name, player1.Data.LevelAdmin.ToString(), Rank.GetRankAdmin(player1.Data.LevelAdmin) });
            admins.Show(player);
        }

        [Command("report", Shortcut = "report", UsageMessage = "/report [playerid] [reason]")]
        private static void SendReport(Player player, int playerid, string reason)
        {
            Player player1 = Player.Find(player, playerid);
            if (player1 == player)
            {
                player.SendClientMessage(Color.Red, "Error: No te puedes reportar a ti mismo.");
                return;
            }
            if (player1.Data.LevelAdmin > 0)
            {
                player.SendClientMessage(Color.Red, "Error: Usted no puede reportar a un administrador.");
                return;
            }
            if(Player.Admins.Count == 0)
            {
                player.SendClientMessage(Color.Red, "Error: No hay administradores conectados para enviar el reporte.");
                return;
            }
            SendMessageToAdmins($"* {player.Name}({player.Id}) reportó a {player1.Name}({player1.Id}) [Razón: {reason}].", Color.Red);
            player.GameText("Reporte Enviado", 3000, 4);
            player.PlaySound(1058);
        }

        public static void SendMessageToAdmins(string message, Color color)
        {
            if (Player.Admins.Count > 0)
            {
                foreach (Player player in Player.Admins)
                    player.SendClientMessage(color, message);
            }
        }

        public static void SendMessageToAdmins(Player player, string command)
        {
            foreach (Player player1 in Player.Admins)
                if(player1 != player)
                    player1.SendClientMessage(Color.Orange, $"[{Rank.GetRankAdmin(player.Data.LevelAdmin)}]: {player.Name} usó el comando /{command}");
        }
    }
}
