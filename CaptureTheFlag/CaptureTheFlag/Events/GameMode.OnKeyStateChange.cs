using CaptureTheFlag.Command.Public;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using static SampSharp.GameMode.Tools.KeyUtils;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerKeyStateChanged(BasePlayer sender, KeyStateChangedEventArgs e)
        {
            base.OnPlayerKeyStateChanged(sender, e);
            var player = sender as Player;

            if (HasPressed(e, Keys.Yes))
                CmdPublic.Weapons(player);
            else if (HasPressed(e, Keys.No))
                CmdPublic.UsersList(player);
            else if (HasPressed(e, Keys.CtrlBack))
                CmdPublic.Combos(player);
            else if ((((e.OldKeys & Keys.Walk) != 0) && ((e.NewKeys & Keys.Crouch) != 0)) && !HasReleased(e, Keys.Walk))
            {
                if (player.SpecialAction == SpecialAction.Duck)
                    player.ToggleControllable(true);
                CmdPublic.PacketWeapons(player);
            }
            if (!player.IsCapturedFlag() && (player.JumpOn || player.IsEnableJump()) && HasPressed(e, Keys.Jump))
                player.Velocity = new Vector3(player.Velocity.X, player.Velocity.Y, 0.24);
            if (player.IsEnableSpeed() && HasPressed(e, Keys.Sprint))
                player.ApplyAnimation("PED", "sprint_civi", 100, true, true, true, true, 500);
        }
    }
}