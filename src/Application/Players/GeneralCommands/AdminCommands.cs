namespace CTF.Application.Players.GeneralCommands;

public class AdminCommands(
    IServerService serverService,
    IWorldService worldService,
    IDialogService dialogService) : ISystem
{
    [PlayerCommand("goto")]
    public void GoToPlayerPosition(
        Player currentPlayer, 
        [CommandParameter(Name = "playerId")]Player targetPlayer)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        if (currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        currentPlayer.Position = targetPlayer.Position;
    }

    [PlayerCommand("get")]
    public void BringPlayerToMyPosition(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        if (currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        targetPlayer.Position = currentPlayer.Position;
    }

    [PlayerCommand("ban")]
    public void BanPlayer(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        string reason)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        if (currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        const int MaxLength = 50;
        if (reason.Length > MaxLength)
        {
            var message = Smart.Format(Messages.BanReason, new { Length = MaxLength });
            currentPlayer.SendClientMessage(Color.Red, message);
            return;
        }

        {
            var message = Smart.Format(Messages.SuccessfullyBanned, new
            {
                CurrentPlayer = currentPlayer.Name,
                TargetPlayer = targetPlayer.Name,
                Reason = reason
            });
            worldService.SendClientMessage(Color.Red, message);
        }
        targetPlayer.Ban(reason);
    }

    [PlayerCommand("unban")]
    public void UnbanPlayer(Player currentPlayer, string ip)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        var message = Smart.Format(Messages.SuccessfullyUnbanned, new { Ip = ip });
        currentPlayer.SendClientMessage(Color.Yellow, message);
        serverService.SendRconCommand($"unbanip {ip}");
    }

    [PlayerCommand("bannedips")]
    public void ShowBannedIPs(Player currentPlayer)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        var path = Path.Combine(Directory.GetCurrentDirectory(), "samp.ban");
        var bannedIPs = File.ReadAllLines(path);
        if (bannedIPs.Length == 0)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.NoMatchFound);
            return;
        }

        var dialog = new ListDialog(caption: $"Banned IPs: {bannedIPs.Length}", "Close");
        foreach (string bannedIP in bannedIPs)
        {
            dialog.Add(bannedIP);
        }

        dialogService.ShowAsync(currentPlayer, dialog);
    }
}
