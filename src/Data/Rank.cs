using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Data
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
            new Rank("Semi-Advanced",   150),
            new Rank("Advanced",        200),
            new Rank("Hitman",          250),
            new Rank("Extreme",         300),
            new Rank("Annihilator",     350),
            new Rank("Maniac",          400),
            new Rank("Invincible",      450),
            new Rank("Senior",          500),
            new Rank("GameMaster",      550),
            new Rank("Professional",    600),
            new Rank("SuperPro",        650),
            new Rank("Legendary",       700)
        };

        private static string[] rankVip = new[]
        {
            "Silver",
            "Gold",
            "Premium"
        };

        private static string[] rankAdmin = new[]
        {
            "Ayudante",
            "Moderador",
            "Administrator",
            "Dueño"
        };

        public static string GetRankVip(int index) => rankVip[index - 1];
        public static string GetRankAdmin(int index) => rankAdmin[index - 1];
        public static string GetRankLevel(int level) => rankGame[level - 1].nameRank;
        public static string GetNextRankLevel(int level) => (level != MAX_RANK) ? GetRankLevel(level + 1) : "None";
        public static int GetRequiredKills(int level) => rankGame[level - 1].kills;
    }
}
