using CaptureTheFlag.Constants;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerPickUpPickup(BasePlayer sender, PickUpPickupEventArgs e)
        {
            base.OnPlayerPickUpPickup(sender, e);
            var player = sender as Player;
            (e.Pickup.Model == FlagID.Alpha ? TeamAlpha : TeamBeta).ExecuteAction(player, e.Pickup);
        }
    }
}