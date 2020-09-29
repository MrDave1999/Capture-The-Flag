using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class Rank
    {
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
    }
}
