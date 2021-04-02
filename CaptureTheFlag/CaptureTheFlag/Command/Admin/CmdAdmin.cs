using CaptureTheFlag.Data;
using CaptureTheFlag.Permission;
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
        [Command("admin", Shortcut = "admin")]
        private static void UsageMessage(Player player)
        {
            player.SendClientMessage(Color.Red, "Usage: /admin [1-4]");
        }

        [Command("1")]
        private static void Cmds_Assistant(Player player)
        {
            if (player.IsAdminLevel(1)) return;
            new MessageDialog("Comandos - Ayudante (Nivel 1)",
                $"{Color.Yellow}/changemap{Color.White} - Cambia el mapa actual del servidor." +
                $"\n{Color.Yellow}/resetflags{Color.White} - Regresa las banderas a su posición inicial." +
                $"\n{Color.Yellow}/ip{Color.White} - Muestra la IP de un jugador." +
                $"\n{Color.Yellow}/spec{Color.White} - Permite espiar a un jugador." +
                $"\n{Color.Yellow}/specoff{Color.White} - Sales de modo espectador." +
                $"\n{Color.Yellow}/warn{Color.White} - Permite advertir a un jugador." +
                $"\n{Color.Yellow}/slap{Color.White} - Le da una bofetada a un jugador." +
                $"\n{Color.Yellow}/setworld{Color.White} - Establece el mundo virtual a un jugador." +
                $"\n{Color.Yellow}/ac{Color.White} -  Permite hablar en el AdminChat." +
                $"\n{Color.Yellow}/benefit{Color.White} - Muestra los beneficios (canjeados por adrenalina) de algún jugador." +
                $"\n{Color.Yellow}/asay{Color.White} - Te permite hablar como administrador." +
                $"\n\n{Color.Orange}También puedes hablar en el Admin Chat con el signo: {Color.White}#texto" +
                $"\n{Color.Orange}Puedes hablar como administrador con el signo: {Color.White}&texto", "Aceptar", "").Show(player);
        }

        [Command("2")]
        private static void Cmds_Moderator(Player player)
        {
            if (player.IsAdminLevel(2)) return;
            new MessageDialog("Comandos - Moderador (Nivel 2)",
                 $"{Color.Yellow}/spawn{Color.White} - Permite reaparecer a un jugador." +
                 $"\n{Color.Yellow}/kick{Color.White} - Permite expulsar a un jugador." +
                 $"\n{Color.Yellow}/announce{Color.White} - Permite dar un anuncio a todos los jugadores." +
                 $"\n{Color.Yellow}/announce2{Color.White} - Permite dar un anuncio (estilo 2) a todos los jugadores." +
                 $"\n{Color.Yellow}/mute{Color.White} - Permite que el jugador no pueda escribir en el chat." +
                 $"\n{Color.Yellow}/unmute{Color.White} - Hace que el jugador si pueda escribir en el chat." +
                 $"\n{Color.Yellow}/clearallchat{Color.White} - Limpia los mensajes del chat de todos los jugadores." +
                 $"\n{Color.Yellow}/freeze{Color.White} - Permite congelar a un jugador." +
                 $"\n{Color.Yellow}/unfreeze{Color.White} - Le quita el congelamiento al jugador." +
                 $"\n{Color.Yellow}/healall{Color.White} - Regenera la salud a todos los jugadores." +
                 $"\n{Color.Yellow}/armourall{Color.White} - Le da chaleco AntiBalas a todos los jugadores." +
                 $"\n{Color.Yellow}/explode{Color.White} - Explota a un determinado jugador.", "Aceptar", "").Show(player);
        }

        [Command("3")]
        private static void Cmds_Administrator(Player player)
        {
            if (player.IsAdminLevel(3)) return;
            new MessageDialog("Comandos - Admin (Nivel 3)",
                $"{Color.Yellow}/goto{Color.White} - Permite teletransportarse hacia un jugador." +
                $"\n{Color.Yellow}/get{Color.White} - Trae a un jugador hacia la posición del administrador." +
                $"\n{Color.Yellow}/banip{Color.White} - Permite prohibir la IP de un jugador." +
                $"\n{Color.Yellow}/unbanip{Color.White} - Permite desprohibir la IP de un jugador." +
                $"\n{Color.Yellow}/banips{Color.White} - Muestra todas las IPs prohibidas." +
                $"\n{Color.Yellow}/nameban{Color.White} - Permite prohibir la cuenta de un jugador." +
                $"\n{Color.Yellow}/dnameban{Color.White} - Permite desprohibir la cuenta de un jugador." +
                $"\n{Color.Yellow}/namebans{Color.White} - Muestra todos las cuentas prohibidas." +
                $"\n{Color.Yellow}/setkills{Color.White} - Permite establecer los asesinatos a un jugador." +
                $"\n{Color.Yellow}/setadre{Color.White} - Permite establecer la adrenalina a un jugador.", "Aceptar", "").Show(player);
        }

        [Command("4")]
        private static void Cmds_Owner(Player player)
        {
            if (player.IsAdminLevel(4)) return;
            new MessageDialog("Comandos - Dueño (Nivel 4)",
                $"{Color.Yellow}/setlevel{Color.White} - Permite asignar un nivel administrativo a un jugador." +
                $"\n{Color.Yellow}/setvip{Color.White} - Permite asignar un nivel VIP a un jugador." +
                $"\n{Color.Yellow}/lockserver{Color.White} - Bloquea el servidor con una contraseña." +
                $"\n{Color.Yellow}/unlockserver{Color.White} - Desbloquea el servidor." +
                $"\n{Color.Yellow}/restartserver{Color.White} - Reinicia el servidor." +
                $"\n{Color.Yellow}/settimeleft{Color.White} - Cambia el tiempo restante de la partida.", "Aceptar", "").Show(player);
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
