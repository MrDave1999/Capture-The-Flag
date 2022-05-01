namespace CaptureTheFlag.Events;

public partial class GameMode : BaseMode
{
    protected override void OnPlayerRequestClass(BasePlayer sender, RequestClassEventArgs e)
    {
        var player = sender as Player;
        if (player.IsStateUser == StateUser.Kill)
        {
            player.IsStateUser = StateUser.None;
            player.SetSpawnInfo(0, 0, new Vector3(0, 0, 0), 0);
            player.Spawn();
            return;
        }

        /* Check if the player has died before entering class selection. */
        if (player.IsDead)
        {
            Player.Remove(player);
            TextDrawGlobal.UpdateCountUsers();
            TextDrawGlobal.Hide(player);
            TextDrawPlayer.Hide(player);
        }

        player.Color = ColorWhite;
        player.Team = BasePlayer.NoTeam;
        player.IsSelectionClass = true;
        player.Position = new Vector3(-1389.137451, 3314.043701, 20.493314);
        player.CameraPosition = new Vector3(-1399.776000, 3310.254150, 21.525623);
        player.SetCameraLookAt(new Vector3(-1395.072143, 3311.873291, 22.027709));
        player.Angle = 111.68f;
        player.Interior = 0;
        player.PlayerTeam = (e.ClassId == 0) ? (TeamAlpha) : (TeamBeta);
        player.PlayerTeam.GetMessageTeamEnable(out var msg);
        player.GameText(msg, 999999999, 3);
        player.PlaySound(1132);
        player.IsDead = false;
    }
}
