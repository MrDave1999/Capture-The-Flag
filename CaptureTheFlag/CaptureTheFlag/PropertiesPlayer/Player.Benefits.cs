using SampSharp.Core.Natives.NativeObjects;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.PropertiesPlayer
{
    public class YsfNatives : NativeObjectSingleton<YsfNatives>
    {
        [NativeMethod]
        public virtual int ShowPlayerForPlayer(int forplayerid, int playerid, bool setskin = false)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod]
        public virtual int HidePlayerForPlayer(int forplayerid, int playerid)
        {
            throw new NativeNotImplementedException();
        }
    }

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

        public void ShowPlayerForPlayer(Player forplayer)
        {
            YsfNatives.Instance.ShowPlayerForPlayer(forplayer.Id, Id);
        }

        public void HidePlayerForPlayer(Player forplayer)
        {
            YsfNatives.Instance.HidePlayerForPlayer(forplayer.Id, Id);
        }

        public void EnableInvisibility()
        {
            foreach(Player player in GetAll<Player>())
            {
                if (!player.IsConnected) continue;
                HidePlayerForPlayer(player);
            }
        }

        public void DisableInvisibility()
        {
            foreach (Player player in GetAll<Player>())
            {
                if (!player.IsConnected) continue;
                ShowPlayerForPlayer(player);
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
