using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class PlayerData
    {
        public string password { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int LevelAdmin { get; set; }
        public int LevelVip { get; set; }
        public int LevelGame { get; set; }
        public int DroppedFlags { get; set; }
    }
}
