namespace CaptureTheFlag.Events;

public partial class GameMode : BaseMode
{
    protected override void OnPlayerConnected(BasePlayer sender, EventArgs e)
    {
        base.OnPlayerConnected(sender, e);
        var player = sender as Player;
        player.PlayAudioStream("https://dl.dropboxusercontent.com/s/80g6s720ogyoy98/intro-cs.mp3");
        player.Color = ColorWhite;
        player.Team = BasePlayer.NoTeam;
        player.IsSelectionClass = true;
        BasePlayer.SendDeathMessageToAll(null, player, Weapon.Connect);
        TextDrawEntry.Show(player);
        player.RemoveAttachedObject(0);
    }
}
