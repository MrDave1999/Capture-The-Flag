using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class Rank
    {
        public static readonly int MAX_RANK = 15;
        private string nameRank;
        private int kills;

        private Rank(string nameRank, int kills)
        {
            this.nameRank = nameRank;
            this.kills = kills;
        }

        private static Rank[] rankGame = new[]
        {
            new Rank("Noob",            0),
            new Rank("Medium",          50),
            new Rank("Junior",          100),
            new Rank("Semi-Advanced",   200),
            new Rank("Advanced",        300),
            new Rank("Hitman",          400),
            new Rank("Extreme",         500),
            new Rank("Aniquilador",     600),
            new Rank("Maniático",       700),
            new Rank("Invencible",      800),
            new Rank("Senior",          900),
            new Rank("GameMaster",      1000),
            new Rank("Pro",             2000),
            new Rank("SuperPro",        3000),
            new Rank("Legendary",       4000)
        };

        private static string[] rankVip = new[]
        {
            "Ninguno",
            "Silver",
            "Gold",
            "Premium"
        };

        private static string[] rankAdmin = new[]
        {
            "Ninguno",
            "Postulante",
            "Moderador",
            "Admin",
            "Encargado",
            "Dueño"
        };

        public static string GetRankVip(int index)
        {
            return rankVip[index];
        }

        public static string GetRankAdmin(int index)
        {
            return rankAdmin[index];
        }

        public static string GetRankLevel(int level)
        {
            return rankGame[level - 1].nameRank;
        }

        public static int GetRequiredKills(int level)
        {
            return rankGame[level - 1].kills;
        }
    }
}
