using CaptureTheFlag.Command.Public;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.Tools;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerKeyStateChanged(BasePlayer sender, KeyStateChangedEventArgs e)
        {
            base.OnPlayerKeyStateChanged(sender, e);
            var player = sender as Player;

            if (KeyUtils.HasPressed(e, Keys.Yes))
                CmdPublic.Weapons(player);
            else if (KeyUtils.HasPressed(e, Keys.No))
                CmdPublic.UsersList(player);
            else if (KeyUtils.HasPressed(e, Keys.CtrlBack))
                CmdPublic.Combos(player);

            if (player.IsEnableJump() && KeyUtils.HasPressed(e, Keys.Jump))
                player.Velocity = new Vector3(player.Velocity.X, player.Velocity.Y, 0.24);

            if (player.IsEnableSpeed() && KeyUtils.HasPressed(e, Keys.Sprint))
                player.ApplyAnimation("PED", "sprint_civi", 100, true, true, true, true, 500);
        }
    }
}