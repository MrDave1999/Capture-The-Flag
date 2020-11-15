using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class PlayerData
    {
        public string password { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int KillingSprees { get; set; }
        public int LevelAdmin { get; set; }
        public int LevelVip { get; set; }
        public int LevelGame { get; set; } = 1;
        public int DroppedFlags { get; set; }
        public int Headshot { get; set; }
    }
}
