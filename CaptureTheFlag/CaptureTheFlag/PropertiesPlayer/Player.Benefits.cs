using SampSharp.Core.Natives.NativeObjects;
using SampSharp.GameMode.World;
using SampSharp.YSF;

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player : BasePlayer 
    {
        public int JumpTime { get; set; }
        public int SpeedTime { get; set; }
        public int InvisibleTime { get; set; }
        public int HealthTime { get; set; }
        public int ArmourTime { get; set; }
        public bool JumpOn { get; set; }
        public bool IsInvisible { get; set; }

        public bool IsEnableJump()
        {
            return JumpTime > Time.GetTime();
        }

        public bool IsEnableSpeed()
        {
            return SpeedTime > Time.GetTime();
        }

        public bool IsEnableInvisible()
        {
            return InvisibleTime > Time.GetTime();
        }

        public void EnableInvisibility()
        {
            foreach(Player player in GetAll<Player>())
            {
                if (!player.IsConnected) continue;
                YSF.HidePlayerForPlayer(player, this);
            }
        }

        public void DisableInvisibility()
        {
            foreach (Player player in GetAll<Player>())
            {
                if (!player.IsConnected) continue;
                YSF.ShowPlayerForPlayer(player, this);
                Skin = (Data.SkinId != -1) ? Data.SkinId : PlayerTeam.Skin;
                Team = (int)PlayerTeam.Id;
                if(IsCapturedFlag())
                {
                    RemoveAttachedObject(0);
                    PlayerTeam.TeamRival.Flag.AttachedObject(this);
                }
            }
        }
    }
}
