using SampSharp.GameMode.World;

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player : BasePlayer 
    {
        public int JumpTime { get; set; }
        public int SpeedTime { get; set; }
        public int HealthTime { get; set; }
        public int ArmourTime { get; set; }
        public bool JumpOn { get; set; }


        public bool IsEnableJump()
        {
            return JumpTime > Time.GetTime();
        }

        public bool IsEnableSpeed()
        {
            return SpeedTime > Time.GetTime();
        }
    }
}
