using CaptureTheFlag.Command.Public;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player
    {
        public bool AFK { get; set; }
        public static List<UserAFK> UserAFKs = new List<UserAFK>();
    }
}

namespace CaptureTheFlag.Command.Public
{
    public class UserAFK : IEquatable<UserAFK>
    {
        public Player Player { get; set; }
        public string EntryHour { get; set; }

        public bool Equals(UserAFK userAFK) => Player.Id == userAFK.Player.Id;

        public new string[] ToString()
            => new[]{ Player.Id.ToString(), Player.Name, EntryHour };
    }

    public partial class CmdPublic
    {
        [Command("afk", Shortcut = "afk")]
        private static void Afk(Player player)
        {
            if (player.AFK)
            {
                player.SendClientMessage(Color.Red, "Error: Ya estás en modo AFK.");
                return;
            }
            if(player.IsCapturedFlag())
            {
                player.SendClientMessage(Color.Red, "Error: No puedes estar en modo AFK (usa /kill).");
                return;
            }
            if (player.Health < 85)
            {
                player.SendClientMessage(Color.Red, "Error: No tienes suficiente salud para usar este comando.");
                return;
            }
            Player.UserAFKs.Add(new UserAFK() { Player = player, EntryHour = DateTime.Now.ToString("HH:mm:ss tt", CultureInfo.InvariantCulture) });
            player.SetNoTeam();
            player.ToggleControllable(false);
            player.ResetWeapons();
            player.AFK = true;
            player.Position = new Vector3(485.7695, -12.9880, 1000.6797);
            player.Angle = 243.1791f;
            player.Interior = 17;
            BasePlayer.SendClientMessageToAll(Color.Orange, $"* {player.Name} está ahora en modo AFK. {Color.Red}[Usuarios: {Player.UserAFKs.Count}].");
        }

        [Command("outafk", Shortcut = "outafk")]
        private static void OutAfk(Player player)
        {
            if(!player.AFK)
            {
                player.SendClientMessage(Color.Red, "Error: No estás en modo AFK.");
                return;
            }
            Player.UserAFKs.Remove(new UserAFK() { Player = player});
            player.AFK = false;
            player.ToggleControllable(true);
            player.SetForceClass();
            BasePlayer.SendClientMessageToAll(Color.Orange, $"* {player.Name} salió del modo AFK.");
        }

        [Command("afks", Shortcut = "afks")]
        private static void ListAFKs(Player player)
        {
            if(Player.UserAFKs.Count == 0)
            {
                player.SendClientMessage(Color.Red, "Error: No hay ningún jugador en AFK.");
                return;
            }
            var dialog = new TablistDialog($"AFK users: {Player.UserAFKs.Count}", new[] { "Id", "Name", "Entry Hour"}, "Cerrar", "");
            foreach(UserAFK player1 in Player.UserAFKs)
                dialog.Add(player1.ToString());
            dialog.Show(player);
        }
    }
}
