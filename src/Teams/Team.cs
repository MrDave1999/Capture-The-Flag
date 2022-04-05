using CaptureTheFlag.Map;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using SampSharp.Streamer.World;
using System;
using System.Collections.Generic;
using System.Text;
using CaptureTheFlag.Constants;
using CaptureTheFlag.PropertiesPlayer;

namespace CaptureTheFlag.Teams
{
    public partial class Team
    {
        public TeamID Id { get; private set; }
        public int Members => Players.Count;
        public int Score { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Skin { get; private set; }
        public string NameTeam { get; private set; }
        public string NameColor { get; private set; }
        public string ColorEnglish { get; private set; }
        public string ColorGameText { get; private set; }
        public string OtherColor { get; private set; }
        public Flag Flag { get; private set; }
        public Team TeamRival { get; set; }
        public TextDraw TdScore { get; private set; }
        public DynamicMapIcon Icon { get; private set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public Pickup PickupInfo { get; set; }

        public Team(
            int skin, 
            string otherColor, 
            string colorGameText, 
            TextDraw tdscore, 
            TeamID teamid, 
            string name, 
            string namecolor, 
            string colorEnglish, 
            Flag flag, 
            int interior
            )
        {
            Skin = skin;
            OtherColor = otherColor;
            ColorGameText = colorGameText;
            TdScore = tdscore;
            Id = teamid;
            NameTeam = name;
            NameColor = namecolor;
            ColorEnglish = colorEnglish;
            Flag = flag;
            Icon = new DynamicMapIcon(Flag.PositionBase, 0) { StreamDistance = 5000f, Interior = interior, Color = Flag.ColorHex};
        }

        public bool IsFull() => Members > TeamRival.Members;
        public void UpdateTdScore() => TdScore.Text = $"{ColorGameText}{NameTeam}: {Score}";

        public void ResetStats()
        {
            Score = 0;
            Kills = 0;
            Deaths = 0;
            UpdateTdScore();
        }

        public void UpdateIcon()
        {
            Icon.Position = Flag.PositionBase;
            Icon.Interior = CurrentMap.Interior;
        }
        
        public bool GetMessageTeamEnable(out string message, bool msgComplete = true)
        {
            bool full;
            message = (full = IsFull()) ?
                (msgComplete ? $"~y~{NameTeam}~n~~r~ not available" : "not available") :
                (msgComplete ? $"~y~{NameTeam}~n~~r~ available" : "available");
            return full;
        }

        public void ExecuteAction(Player player, Pickup pickup)
        {
            if (Flag.IsPositionBase)
            {
                if (player.PlayerTeam.Id == TeamRival.Id)
                {
                    Captured(player);
                    pickup.Dispose();
                }
                else if (player == TeamRival.Flag.PlayerCaptured)
                    TeamRival.Carry(player);
            }
            else
            {
                if (player.PlayerTeam.Id == Id)
                    Recover(player);
                else
                    Captured(player, false);
                pickup.Dispose();
            }
        }
    }
}
