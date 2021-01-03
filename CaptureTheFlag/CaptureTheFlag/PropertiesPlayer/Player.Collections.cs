using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using SampSharp.GameMode.SAMP;
using static CaptureTheFlag.GameMode;

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player : BasePlayer
    {
        public static Player Find(Player player, int playerid)
        {
            foreach (Player player1 in GetAll())
                if (player1.Id == playerid)
                    return player1;
            player.SendClientMessage(Color.Red, "Error: Jugador no conectado o se encuentra en la selección de clases.");
            throw new Exception();
        }

        public static void Remove(Player player)
        {
            player.PlayerTeam.Players.Remove(player);
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
