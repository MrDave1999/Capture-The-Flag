namespace CaptureTheFlag.Events;

public partial class GameMode : BaseMode
{
    protected override void OnPlayerDisconnected(BasePlayer sender, DisconnectEventArgs e)
    {
        base.OnPlayerDisconnected(sender, e);
        var player = sender as Player;
        BasePlayer.SendDeathMessageToAll(null, player, Weapon.Disconnect);
        if (player.IsCapturedFlag())
            player.Drop();
        if (player.Team != BasePlayer.NoTeam)
        {
            Player.Remove(player);
            TextDrawGlobal.UpdateCountUsers();
        }
        TextDrawPlayer.Destroy(player);
        TextDrawGlobal.Hide(player);
        Player.RemoveLevels(player);
        if (player.AFK)
            Player.UserAFKs.Remove(new UserAFK() { Player = player });
        player.UpdateData("lastConnection", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
