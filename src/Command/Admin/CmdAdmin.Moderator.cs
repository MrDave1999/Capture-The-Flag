using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using SampSharp.YSF;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Admin
{
    public partial class CmdAdmin
    {
        [Command("spawn", Shortcut = "spawn", UsageMessage = "/spawn [playerid]")]
        private static void SetSpawn(Player player, int playerid)
        {
            if (player.IsAdminLevel(2)) return;
            Player player1 = Player.Find(player, playerid);
            player.SendClientMessage(Color.Yellow, $"* Spawneaste al jugador: {player1.Name}");
            player1.Spawn();
            SendMessageToAdmins(player, "spawn");
        }

        [Command("kick", Shortcut = "kick", UsageMessage = "/kick [playerid] [reason]")]
        private static void Kick(Player player, int playerid, string reason)
        {
            if (player.IsAdminLevel(2)) return;
            Player player1 = Player.Find(player, playerid);
            if (player.Equals(player1, "No puedes expulsarte a ti mismo.")) return;
            BasePlayer.SendClientMessageToAll(Color.Red, $"* {player.Name} ha expulsado al jugador {player1.Name} [Razón: {reason}].");
            SendMessageToAdmins(player, "kick");
            player1.Kick();
        }

        [Command("mute", Shortcut = "mute", UsageMessage = "/mute [playerid] [reason]")]
        private static void Mute(Player player, int playerid, string reason)
        {
            if (player.IsAdminLevel(2)) return;
            Player player1 = Player.Find(player, playerid);
            if (player.Equals(player1, "No puedes silenciarte a ti mismo.")) return;
            if (!player1.IsMuted)
            {
                BasePlayer.SendClientMessageToAll(Color.Red, $"* {player.Name} ha silenciado al jugador {player1.Name} [Razón: {reason}].");
                player1.IsMuted = true;
                SendMessageToAdmins(player, "mute");
            }
            else
                player.SendClientMessage(Color.Red, "Error: El jugador ya se encuentra silenciado.");
        }

        [Command("unmute", Shortcut = "unmute", UsageMessage = "/unmute [playerid]")]
        private static void UnMute(Player player, int playerid)
        {
            if (player.IsAdminLevel(2)) return;
            Player player1 = Player.Find(player, playerid);
            if (player1.IsMuted)
            {
                player1.SendClientMessage(Color.Red, $"* {player.Name} te ha quitado el silencio, por favor no volverlo a hacer.");
                player.SendClientMessage(Color.Yellow, $"* Ahora el jugador {player1.Name} sí podrá escribir en el chat.");
                player1.IsMuted = false;
                SendMessageToAdmins(player, "unmute");
            }
            else
                player.SendClientMessage(Color.Red, "Error: El jugador no se encuentra silenciado.");
        }

        [Command("clearallchat", Shortcut = "clearallchat")]
        private static void ClearAllChat(Player player)
        {
            if (player.IsAdminLevel(2)) return;
            for (int i = 0; i != 100; ++i)
                BasePlayer.SendClientMessageToAll(" ");
            SendMessageToAdmins(player, "clearallchat");
        }

        [Command("freeze", Shortcut = "freeze", UsageMessage = "/freeze [playerid]")]
        private static void Freeze(Player player, int playerid)
        {
            if(player.IsAdminLevel(2)) return;
            Player player1 = Player.Find(player, playerid);
            if(player1.IsFreeze)
            {
                player.SendClientMessage(Color.Red, "Error: El jugador ya se encuentra congelado.");
                return;
            }
            player.SendClientMessage(Color.Yellow, $"* Congelaste al jugador: {player1.Name}.");
            player1.SendClientMessage(Color.Yellow, $"* {player.Name} te ha congelado.");
            player1.ToggleControllable(false);
            player1.IsFreeze = true;
            SendMessageToAdmins(player, "freeze");
        }
        [Command("unfreeze", Shortcut = "unfreeze", UsageMessage = "/unfreeze [playerid]")]
        private static void UnFreeze(Player player, int playerid)
        {
            if (player.IsAdminLevel(2)) return;
            Player player1 = Player.Find(player, playerid);
            if (!player1.IsFreeze)
            {
                player.SendClientMessage(Color.Red, "Error: El jugador ya se encuentra descongelado.");
                return;
            }
            player.SendClientMessage(Color.Yellow, $"* Descongelaste al jugador: {player1.Name}.");
            player1.SendClientMessage(Color.Yellow, $"* {player.Name} te ha descongelado.");
            player1.ToggleControllable(true);
            player1.IsFreeze = false;
            SendMessageToAdmins(player, "unfreeze");
        }

        [Command("healall", Shortcut = "healall")]
        private static void HealAll(Player player)
        {
            if (player.IsAdminLevel(2)) return;
            foreach (Player player1 in Player.GetAll())
                player1.Health = 100f;
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} ha curado a todos los jugadores.");
            SendMessageToAdmins(player, "healall");
        }

        [Command("armourall", Shortcut = "armourall")]
        private static void ArmourAll(Player player)
        {
            if (player.IsAdminLevel(2)) return;
            foreach (Player player1 in Player.GetAll())
                player1.Armour = 100f;
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"* {player.Name} le dio a todos los jugadores un chaleco AntiBalas.");
            SendMessageToAdmins(player, "armourall");
        }

        [Command("explode", Shortcut = "explode", UsageMessage = "/explode [playerid]")]
        private static void Explode(Player player, int playerid)
        {
            if (player.IsAdminLevel(2)) return;
            Player player1 = Player.Find(player, playerid);
            player.SendClientMessage(Color.Yellow, $"* Explotaste al jugador: {player1.Name}.");
            player1.SendClientMessage(Color.Yellow, $"* {player.Name} te ha explotado.");
            player1.CreateExplosion(new Vector3(player1.Position.X, player1.Position.Y, player1.Position.Z), ExplosionType.VerySmallVisibleDamage, 5.0f);
            SendMessageToAdmins(player, "explode");
        }

        [Command("announce", Shortcut = "announce", UsageMessage = "/announce [message]")]
        private static void Announce(Player player, string message)
        {
            if (player.IsAdminLevel(2)) return;
            BasePlayer.GameTextForAll(message, 4000, 5);
            SendMessageToAdmins(player, "announce");
        }

        [Command("announce2", Shortcut = "announce2", UsageMessage = "/announce2 [message]")]
        private static void Announce2(Player player, string message)
        {
            if (player.IsAdminLevel(2)) return;
            BasePlayer.GameTextForAll(message, 4000, 0);
            SendMessageToAdmins(player, "announce2");
        }
    }
}
