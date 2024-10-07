namespace CTF.Application.Players.GeneralCommands;

public class PublicCommands(
    IEntityManager entityManager,
    IWorldService worldService,
    IDialogService dialogService,
    PlayerStatsRenderer playerStatsRenderer) : ISystem
{
    [PlayerCommand("kill")]
    public void Kill(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        if (playerInfo.Team == Team.None)
        {
            player.SendClientMessage(Color.Red, Messages.NoTeam);
            return;
        }
        player.Health = 0;
    }

    [PlayerCommand("re")]
    public void ResetScore(Player player) 
    {
        PlayerInfo playerInfo = player.GetInfo();
        playerInfo.StatsPerRound.ResetKills();
        playerInfo.StatsPerRound.ResetDeaths();
        player.SetScore(0);
        playerStatsRenderer.UpdateTextDraw(player);
        var message = Smart.Format(Messages.PlayerScoreReset, new
        {
            PlayerName = player.Name,
            Color = Color.Red
        });
        worldService.SendClientMessage(Color.Yellow, message);
    }

    [PlayerCommand("admins")]
    public void ShowAdmins(Player currentPlayer)
    {
        IEnumerable<PlayerInfo> admins = entityManager
            .GetComponents<Player>()
            .Select(player => player.GetInfo())
            .Where(playerInfo => playerInfo.RoleId >= RoleId.Moderator)
            .OrderByDescending(playerInfo => playerInfo.RoleId);

        int count = admins.Count();
        if (count == 0)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.NoMatchFound);
            return;
        }
        var dialog = new ListDialog(caption: $"Admins: {count}", "Close", "");
        foreach (PlayerInfo playerInfo in admins)
        {
            dialog.Add(playerInfo.Name);
        }
        dialogService.ShowAsync(currentPlayer, dialog);
    }

    [PlayerCommand("vips")]
    public void ShowVIPs(Player currentPlayer)
    {
        IEnumerable<PlayerInfo> vips = entityManager
            .GetComponents<Player>()
            .Select(player => player.GetInfo())
            .Where(playerInfo => playerInfo.RoleId >= RoleId.VIP);

        int count = vips.Count();
        if (count == 0)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.NoMatchFound);
            return;
        }
        var dialog = new ListDialog(caption: $"VIPs: {count}", "Close", "");
        foreach (PlayerInfo playerInfo in vips)
        {
            dialog.Add(playerInfo.Name);
        }
        dialogService.ShowAsync(currentPlayer, dialog);
    }
}
