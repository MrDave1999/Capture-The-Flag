namespace CaptureTheFlag.Events;

public partial class GameMode : BaseMode
{
    protected override void OnPlayerPickUpPickup(BasePlayer sender, PickUpPickupEventArgs e)
    {
        base.OnPlayerPickUpPickup(sender, e);
        var player = sender as Player;
        if(e.Pickup.Model == FlagID.Alpha)
            TeamAlpha.ExecuteAction(player, e.Pickup);
        else if(e.Pickup.Model == FlagID.Beta)
            TeamBeta.ExecuteAction(player, e.Pickup);
    }
}
