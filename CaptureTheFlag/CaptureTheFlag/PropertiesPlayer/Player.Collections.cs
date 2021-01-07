using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using SampSharp.GameMode.SAMP;
using static CaptureTheFlag.GameMode;

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player : BasePlayer
    {
        public static List<Player> Admins { get; set; } = new List<Player>();
        public static List<Player> Vips { get; set; } = new List<Player>();

        public static Player Find(Player player, int playerid)
        {
            Player player1 = (Player)Find(playerid);
            if (player1 == null || !player1.IsConnected)
            {
                player.SendClientMessage(Color.Red, "Error: El jugador no se encuentra conectado.");
                throw new Exception();
            }
            return player1;
        }

        public static void Remove(Player player)
        {
            player.PlayerTeam.Players.Remove(player);
        }

        public static void AddAV(Player player)
        {
            if (player.Data.LevelAdmin > 0)
                Admins.Add(player);
            if (player.Data.LevelVip > 0)
                Vips.Add(player);
        }

        public static void RemoveAV(Player player)
        {
            if (player.Data.LevelAdmin > 0)
                Admins.Remove(player);
            if (player.Data.LevelVip > 0)
                Vips.Remove(player);
        }

        public static void Add(Player player)
        {
            player.PlayerTeam.Players.Add(player);
        }

        public static IEnumerable<Player> GetAll()
        {
            foreach (Player player in TeamAlpha.Players)
                yield return player;

            foreach (Player player in TeamBeta.Players)
                yield return player;
        }

        public static int Count()
        {
            return TeamAlpha.Members + TeamBeta.Members;
        }

    }
}
