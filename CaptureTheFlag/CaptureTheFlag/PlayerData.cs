using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    /*
        -> Stats Player:
        Kills for Round,
        Deaths for Round,
        Total Kills,
        Total Deaths,
        Admin Level,
        VIP Level,
        Rank,
        Game Level or Lvl,
        DroppedFlags,
        Killing Sprees,
        Adrenaline
    */
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
    }
}
