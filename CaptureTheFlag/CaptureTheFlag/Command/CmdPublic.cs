using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.GameMode;
using CaptureTheFlag.Constants;
using SampSharp.Streamer.World;
namespace CaptureTheFlag.Command
{
    static class ExtensionTablistDialog
    {
        public static void SetInfo(this TablistDialog vs)
        {
            vs.Clear();
            TeamAlpha.GetMessageTeamEnable(out var msgAlpha, false);
            TeamBeta.GetMessageTeamEnable(out var msgBeta, false);
            vs.Add(new[]
            {       
                $"{TeamAlpha.OtherColor}{TeamAlpha.NameTeam}",
                $"{TeamAlpha.OtherColor}{TeamAlpha.Members}",
                $"{TeamAlpha.OtherColor}{msgAlpha}"
            });
            vs.Add(new[]
            {
                $"{TeamBeta.OtherColor}{TeamBeta.NameTeam}",
                $"{TeamBeta.OtherColor}{TeamBeta.Members}",
                $"{TeamBeta.OtherColor}{msgBeta}"
            });
        }

        public static void ShowDialog(this TablistDialog vs, Player player)
        {
            vs.SetInfo();
            vs.Show(player);
        }
    }
    
    [CommandGroup("public", PermissionChecker = typeof(BlockCommand))]
    public class CmdPublic
    {
        [Command("listplayers", Shortcut = "listplayers")]
        public static void ListPlayers(BasePlayer player)
        { //test command 
            player.SendClientMessage($"Players available: {Player.Count()}");
            try
            {
                foreach (var p in Player.GetAll())
                {
                    player.SendClientMessage("Player: " + p.Name);
                }
            }
            catch (Exception e)
            {
                player.SendClientMessage(Color.Red, e.Message);
            }
        }

        [Command("adre", Shortcut = "adre")]
        private static void Test(Player player)
        { //test command
            player.Adrenaline = 100;
            player.Kills = Rand.Next(4000);
            TextDrawPlayer.UpdateTdStats(player);
        }

        [Command("cmds", Shortcut = "cmds")]
        private static void ListCommands(Player player)
        {
            new MessageDialog(" ",
                $"{Color.Orange}Comandos:" +
                $"\n{Color.Yellow}/kill - {Color.White} Asesina al jugador (su vida queda en 0.0)." +
                $"\n{Color.Yellow}/tstats - {Color.White} Muestra las estadísticas de ambos equipos (Alpha y Beta)." +
                $"\n{Color.Yellow}/switch - {Color.White} Permite al jugador cambiarse de equipo." +
                $"\n{Color.Yellow}/tc - {Color.White} Permite hablar en el Team Chat." +
                $"\n{Color.Yellow}/re{Color.White} Reinicia a 0 los asesinatos y muertes por ronda." +
                $"\n{Color.Yellow}/help - {Color.White} Muestra información sobre como se debe jugar." +
                $"\n{Color.Yellow}/credits - {Color.White} Muestra las personas que han participado en la creación de la GM." +
                $"\n{Color.Yellow}/admins{Color.White} - Muestra la lista de administradores que están conectados." +
                $"\n{Color.Yellow}/vips{Color.White} - Muestra los usuarios VIP que están conectados." +
                $"\n{Color.Yellow}/stats{Color.White} - Muestra las estadísticas de un jugador conectado." +
                $"\n{Color.Yellow}/statsdb{Color.White} - Muestra las estadísticas de un jugador desconectado." +
                $"\n{Color.Yellow}/combos{Color.White} - Muestra los combos que podrás canjear por adrenalina." +
                $"\n{Color.Yellow}/ranks{Color.White} - Muestra la lista de rangos disponibles." +
                $"\n{Color.Yellow}/weapons{Color.White} - Muestra la lista de armas a elegir." +
                $"\n{Color.Yellow}/packet{Color.White} - Muestra el paquete actual de armas del jugador." +
                $"\n{Color.Yellow}/music{Color.White} - Permite escuchar música por medio de una URL." +
                $"\n{Color.Yellow}/stop{Color.White} - Detiene la música." +
                $"\n\n{Color.Orange}Teclas:" +
                $"\n{Color.Yellow}Tecla H:{Color.White} Muestra el listado de combos a canjear (por adrenalina)." +
                $"\n{Color.Yellow}Tecla Y:{Color.White} Muestra un menú de armas." +
                $"\n{Color.Yellow}Tecla N:{Color.White} Muestra la lista de usuarios conectados (por equipo)." +
                $"\n\n{Color.Orange}Signos:" +
                $"\n{Color.Yellow}Signo (!):{Color.White} Permite hablar en el TeamChat (ejemplo: {Color.Pink}!texto{Color.White})." +
                $"\n{Color.Yellow}Signo (#):{Color.White} Permite hablar en el AdminChat (ejemplo: {Color.Pink}#texto{Color.White})." +
                $"\n{Color.Yellow}Signo ($):{Color.White} Permite hablar en el VipChat (ejemplo: {Color.Pink}$texto{Color.White}).", "Aceptar").Show(player);
        }

        [Command("help", Shortcut = "help")]
        private static void Help(Player player)
        {
            new MessageDialog("Ayuda",
                $"{Color.Yellow}¿Qué es Capture The Flag?" +
                $"\n{Color.White}Capture The Flag es un estilo de juego en el que dos equipos intentan atrapar una bandera." +
                $"\n{Color.White}Si el jugador captura la bandera, debe llevarla a un sitio determinado para que su equipo gane puntos." +
                $"\n{Color.White}Para jugar, los jugadores se dividen en dos equipos, con cada uno en un campo." +
                $"\n{Color.White}Para poder ganar, hay que coger una bandera y llevarla a un determinado sitio." +
                $"\n\n{Color.Yellow}¿A dónde llevo la bandera?" +
                $"\n{Color.White}Si capturaste la bandera, la debes llevar a la posición base donde se encuentre la bandera de tu equipo. " +
                $"\n{Color.White}Esa “posición base” es identificada por un ícono que aparecerá en el mapa radar." +
                $"\n{Color.White}Si eres del equipo {TeamAlpha.OtherColor}Alpha{Color.White}, el ícono será de color {TeamAlpha.OtherColor}Rojo {Color.White}y si eres del equipo {TeamBeta.OtherColor}Beta{Color.White}, el ícono será de color {TeamBeta.OtherColor}Azul." +
                $"\n\n{Color.Yellow}¿Qué pasa si no encuentro la bandera de mi equipo en la posición base?" +
                $"\n{Color.White}Pues tu equipo no ganará puntos. En ese caso, debes recuperar la bandera de tu equipo." +
                $"\n\n{Color.Yellow}¿Cómo recupero la bandera de mi equipo?" +
                $"\n{Color.White}Simple, debes matar al jugador que robó la bandera." +
                $"\n{Color.White}Aunque puede que la bandera quede en algún sitio que no sea la posición base y te toque buscarla." +
                $"\n\n{Color.Yellow}¿Cómo sé quien se robó la bandera de mi equipo?" +
                $"\n{Color.White}Con el comando {Color.Pink}/tstats.", "Aceptar").Show(player);
        }

        [Command("credits", Shortcut = "credits")]
        private static void Credits(Player player)
        {
            new MessageDialog("Créditos", 
                $"{Color.Yellow}Capture The Flag es un proyecto Open Source." +
                $"\n{Color.Orange}Repositorio: {Color.White}https://github.com/MrDave1999/Capture-The-Flag" +
                $"\n{Color.Orange}Creador/Fundador: {Color.White}MrDave1999." +
                $"\n{Color.Orange}Programador: {Color.White}MrDave1999." +
                $"\n{Color.Orange}Mapeadores: {Color.White}DragonZafiro, Elorreli, amirab, JamesT85, haubitze, Amads," +
                $"\nTheYoungCapone, B4MB1[MC], Sleyer, mihaibr, UnuAlex, SpikY_, Niktia_Ruchkov." +
                $"\n{Color.Yellow}Agradecimientos a:" +
                $"\n{Color.Orange}ikkentim {Color.White}por crear SampSharp." +
                $"\n{Color.Orange}rickyah {Color.White}por crear ini-parser." +
                $"\n{Color.Orange}Nickk888SAMP {Color.White}por crear NTD (TextDraw Editor)." +
                $"\n{Color.Orange}samp-incognito {Color.White}por crear streamer-plugin." +
                $"\n\n{Color.Yellow}¡Eres libre de contribuir en el proyecto!", "Aceptar").Show(player);
        }

        [Command("re", Shortcut = "re")]
        private static void ResetScore(Player player)
        {
            player.Kills = 0;
            player.Deaths = 0;
            TextDrawPlayer.UpdateTdStats(player);
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"** {player.Name} ha reseteado su score con {Color.Red}/re");
        }

        [Command("kill", Shortcut = "kill")]
        private static void Kill(Player player)
        {
            player.Health = 0;
        }

        [Command("weapons", Shortcut = "weapons")]
        public static void Weapons(Player player)
        {
            var weapons = new ListDialog("Weapons", "Seleccionar", "Cerrar");
            foreach(Gun gun in Gun.GetInstanceArray())
                weapons.AddItem(gun.Weapon.ToString());
            weapons.Show(player);
            weapons.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    Gun gunSearch;
                    /* Gets the weapon that the player selected in the dialog. */
                    var itemWeapon = Gun.GetWeapon(e.ListItem);
                    /* Check if the weapon the player selected is not in their current weapon pack. */
                    if (player.ListGuns.Find(gun => gun.Weapon == itemWeapon) != null)
                    {
                        player.SendClientMessage(Color.Red, $"Error: {itemWeapon} ya se encuentra en el paquete de armas.");
                        weapons.Show(player);
                        return;
                    }
                    /* Get to which category the weapon the player selected belongs. */
                    var slot = Gun.GetWeaponSlot(itemWeapon);
                    /* Check if there is no weapon with the same category in the player's weapon pack. */
                    if ((gunSearch = player.ListGuns.Find(gun => gun.Slot == slot)) != null)
                        gunSearch.Weapon = itemWeapon;
                    else
                        player.ListGuns.Add(new Gun(itemWeapon));
                    player.GiveWeapon(itemWeapon);
                    player.SendClientMessage(Color.Red, $"[Weapon]: {Color.Yellow}{itemWeapon} se agregó en tu paquete de armas.");
                    weapons.Show(player);
                }
            };
        }

        [Command("packet", Shortcut = "packet")]
        private static void PacketWeapons(Player player)
        {
            if(player.ListGuns.Count == 0)
            {
                player.SendClientMessage(Color.Red, "Error: No tienes ningún elemento en tu paquete de armas.");
                return;
            }
            var packet = new TablistDialog("Packet Weapons", 1, "Eliminar", "Cerrar");
            foreach (Gun gun in player.ListGuns)
                packet.Add(gun.Weapon.ToString());
            packet.Show(player);
            packet.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    player.SendClientMessage(Color.Red, $"[Weapon]: {Color.Yellow}{player.ListGuns[e.ListItem].Weapon} se eliminó de tu paquetes de armas.");
                    player.RemoveWeapon(e.ListItem);
                    packet.Clear();
                    foreach (Gun gun in player.ListGuns)
                        packet.Add(gun.Weapon.ToString());
                    packet.Show(player);
                }
            };
        }

        [Command("combos", Shortcut = "combos")]
        public static void Combos(Player player)
        {
            var combos = new TablistDialog("Combos", new[] {"Combo", "Adrenalina"}, "Canjear", "Cerrar");
            combos.Add(new[]{"150% Health + 100% Armour", "100"});
            combos.Add(new[] { "Jumps", "100" });
            combos.Add(new[] { "Velocity", "100" });
            combos.Add(new[] { "2 Grenades + 20% Armour", "25" });
            combos.Add(new[] { "2 Molotov cocktail + 20% Armour", "25" });
            combos.Add(new[] { "10 Tear gas", "10" });
            combos.Add(new[] { "3 Satchel charges + 30% Armour", "40" });
            combos.Show(player);
            combos.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    switch(e.ListItem)
                    {
                        case 0:
                            player.HasAdrenaline(100);
                            player.Health = 150;
                            player.Armour = 100;
                            player.Adrenaline = 0;
                            break;
                        case 1:
                            player.HasAdrenaline(100);
                            if(player.IsCapturedFlag())
                            {
                                player.SendClientMessage(Color.Red, "Error: Lleva la bandera de forma legal, no seas cobarde jeje!");
                                return;
                            }
                            player.SendClientMessage("** En 1 minuto el beneficio se terminará.");
                            player.JumpTime = Time.GetTime() + (1 * 60000);
                            player.Adrenaline = 0;
                            player.GiveWeapon(Weapon.Parachute, 1);
                            break;
                        case 2:
                            player.HasAdrenaline(100);
                            if (player.IsCapturedFlag())
                            {
                                player.SendClientMessage(Color.Red, "Error: Lleva la bandera de forma legal, no seas cobarde jeje!");
                                return;
                            }
                            player.SendClientMessage("** En 1 minuto el beneficio se terminará.");
                            player.SendClientMessage(Color.Orange, $"[Uso]: {Color.White}Presiona y suelta la tecla [SPACE] para correr.");
                            player.SpeedTime = Time.GetTime() + (1 * 60000);
                            player.Adrenaline = 0;
                            break;
                        case 3:
                            player.HasAdrenaline(25);
                            player.SetWeapon(Weapon.Grenade, 2);
                            player.Armour = 20;
                            player.Adrenaline = -25;
                            break;
                        case 4:
                            player.HasAdrenaline(25);
                            player.SetWeapon(Weapon.Moltov, 2);
                            player.Armour = 20;
                            player.Adrenaline = -25;
                            break;
                        case 5:
                            player.HasAdrenaline(10);
                            player.SetWeapon(Weapon.Teargas, 10);
                            player.Adrenaline = -10;
                            break;
                        default:
                            player.HasAdrenaline(40);
                            player.SetWeapon(Weapon.SatchelCharge, 3);
                            player.GiveWeapon(Weapon.Detonator, 1);
                            player.Armour = 30;
                            player.Adrenaline = -40;
                            break;
                    }
                    BasePlayer.SendClientMessageToAll(Color.Red, $"[Combo]: {Color.Yellow}{player.Name} canjeó su adrenalina por algún beneficio {Color.Red}(con /combos).");
                }
            };
        }

        [Command("stop", Shortcut = "stop")]
        private static void StopMusic(Player player)
        {
            player.StopAudioStream();
            player.GameText("STOP MUSIC", 2000, 3);
        }

        [Command("music", Shortcut = "music")]
        private static void PlayMusic(Player player)
        {
            var music = new InputDialog(" ",
                $"{Color.Yellow}Escribe la URL para reproducir la música. Los formatos válidos son mp3 y ogg/vorbis." +
                "\nUn enlace a un archivo .pls (lista de reproducción) reproducirá esa lista de reproducción." +
                $"\n\n{Color.Orange}Se recomienda los siguientes convertidores a MP3:" +
                $"\n{Color.Yellow}notube.net" +
                "\nytmp3.cc", 
                false, "Reproducir", "Cerrar");
            music.Response += (sender, e) =>
            {
                if(e.DialogButton == DialogButton.Left)
                    player.PlayAudioStream(e.InputText);
            };
            music.Show(player);
        }

        [Command("tstats", Shortcut = "tstats")]
        private static void StatsTeam(Player player)
        {
            new MessageDialog("Stats Team",
                TeamAlpha.OtherColor +
                "Team: Alpha" +
                "\nColor Team: Red" +
                "\nUsers: " + TeamAlpha.Members +
                "\nScore: " + TeamAlpha.Score +
                "\nTotal Kills: " + TeamAlpha.Kills +
                "\nTotal Deaths: " + TeamAlpha.Deaths +
                "\nCaptured Flag by: " + (TeamAlpha.Flag.PlayerCaptured == null ? "None" : $"{TeamAlpha.Flag.PlayerCaptured.Name}") +
                TeamBeta.OtherColor +
                "\n\nTeam: Beta" +
                "\nColor Team: Blue" +
                "\nUsers: " + TeamBeta.Members +
                "\nScore: " + TeamBeta.Score +
                "\nTotal Kills: " + TeamBeta.Kills +
                "\nTotal Deaths: " + TeamBeta.Deaths +
                "\nCaptured Flag by: " + (TeamBeta.Flag.PlayerCaptured == null ? "None" : $"{TeamBeta.Flag.PlayerCaptured.Name}"), "Aceptar").Show(player);
        }

        [Command("ranks", Shortcut = "ranks")]
        private static void RanksDialog(Player player)
        {
            var ct = new TablistDialog("Ranks",
                new[] {
                    "Level",
                    "Rank",
                    "Kills Required"
                }, "Cerrar", "");
            for (int i = Rank.MAX_RANK; i != 0; --i)
                ct.Add(i.ToString(), Rank.GetRankLevel(i), Rank.GetRequiredKills(i).ToString());
            ct.Show(player);
        }

        [Command("stats", Shortcut = "stats")]
        private static void StatsPlayer(Player player, int playerid = - 1)
        {
            Player player1 = (playerid != -1 ? Player.Find(player, playerid) : player);
            var level = player1.Data.LevelGame;
            new MessageDialog($"Name: {player1.Name}",
                $"{Color.Yellow}ID: {Color.White}{player1.Id}" +
                $"\n{Color.Yellow}Kills for Round: {Color.White}{player1.Kills}" +
                $"\n{Color.Yellow}Deaths for Round: {Color.White}{player1.Deaths}" +
                $"\n{Color.Yellow}Total Kills: {Color.White}{player1.Data.TotalKills}" +
                $"\n{Color.Yellow}Total Deaths: {Color.White}{player1.Data.TotalDeaths}" +
                $"\n{Color.Yellow}Admin Level: {Color.White}{player1.Data.LevelAdmin}" +
                $"\n{Color.Yellow}VIP Level: {Color.White}{player1.Data.LevelVip}" +
                $"\n{Color.Yellow}Rank: {Color.White}{Rank.GetRankLevel(level)}" +
                $"\n{Color.Yellow}Level: {Color.White}{player1.Data.LevelGame}" +
                $"\n{Color.Yellow}Next Rank: {Color.White}{(level != Rank.MAX_RANK ? Rank.GetRankLevel(level + 1) : "None")}" +
                $"\n{Color.Yellow}DroppedFlags: {Color.White}{player1.Data.DroppedFlags}" +
                $"\n{Color.Yellow}Killing Sprees: {Color.White}{player1.Data.KillingSprees}" +
                $"\n{Color.Yellow}Headshot: {Color.White}{player1.Data.Headshot}" +
            $"\n{Color.Yellow}Adrenaline: {Color.White}{player1.Adrenaline}/100", "Cerrar", "").Show(player);
        }

        [Command("switch", Shortcut = "switch")]
        private static void ChangeTeam(Player player)
        {
            TeamAlpha.GetMessageTeamEnable(out var msgAlpha, false);
            TeamBeta.GetMessageTeamEnable(out var msgBeta, false);
            var ct = new TablistDialog("Change Team", 
                new[] { 
                    "Name",
                    "Users",
                    "Availability"
                }, "Seleccionar", "Cerrar");
            ct.ShowDialog(player);
            ct.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    if (player.PlayerTeam.Id == (TeamID)e.ListItem)
                    {
                        player.SendClientMessage(Color.Red, "Error: Ya formas parte de ese equipo.");
                        ct.ShowDialog(player);
                        return;
                    }
                    if(TeamAlpha.Members == TeamBeta.Members)
                    {
                        player.SendClientMessage(Color.Red, $"Error: No puedes cambiarte al equipo {(e.ListItem == 0 ? "Alpha" : "Beta")} porque el equipo {player.PlayerTeam.NameTeam} quedaría desequilibrado.");
                        ct.ShowDialog(player);
                        return;
                    }
                    if (player.PlayerTeam.TeamRival.IsFull())
                    {
                        player.SendClientMessage(Color.Red, "Error: El equipo no está disponible.");
                        ct.ShowDialog(player);
                        return;
                    }
                    if (player.IsCapturedFlag())
                        player.Drop();
                    Player.Remove(player);
                    player.PlayerTeam = (e.ListItem == 0) ? TeamAlpha : TeamBeta;
                    Player.Add(player);
                    BasePlayer.SendClientMessageToAll($"{player.PlayerTeam.OtherColor}[Team {player.PlayerTeam.NameTeam}]: {player.Name} se cambió al equipo {player.PlayerTeam.NameTeam}.");
                    TextDrawGlobal.UpdateCountUsers();
                    player.Spawn();
                }
            };
        }

        [Command("users", Shortcut = "users")]
        public static void UsersList(Player player)
        {
            var users = new TablistDialog(
                $"{TeamAlpha.OtherColor}Alpha: {TeamAlpha.Members} {TeamBeta.OtherColor}Beta: {TeamBeta.Members}",
                new[] {
                    "Id",
                    "Name",
                    "Kills",
                    "Deaths"
                }, "Cerrar", "");
            TeamAlpha.Players.Sort((a, b) => b.Kills - a.Kills);
            TeamBeta.Players.Sort((a, b) => b.Kills - a.Kills);
            foreach (Player player1 in TeamAlpha.Players)
                users.Add(player1.ToString());
            if(TeamAlpha.Members > 0)
                users.Add(" ", " ", " ", " ");
            foreach (Player player1 in TeamBeta.Players)
                users.Add(player1.ToString());
            users.Show(player);
        } 

        [Command("tc", Shortcut = "tc", UsageMessage = "/tc [message]")]
        public static void TeamChat(Player player, string msg)
        {
            if(player.Team == BasePlayer.NoTeam)
            {
                player.SendClientMessage(Color.Red, "Error: Debes estar en un equipo para usar el TeamChat.");
                return;
            }
            foreach(Player player1 in player.PlayerTeam.Players)
                player1.SendClientMessage($"{player.PlayerTeam.OtherColor}[Team Chat] {player.Name} [{player.Id}]: {msg}");
        }
    }
}
