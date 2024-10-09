namespace CTF.Application.Players.GeneralCommands;

public class AdminCommands(
    IServerService serverService,
    IWorldService worldService,
    IDialogService dialogService) : ISystem
{
    [PlayerCommand("cmdsadmin")]
    public void ShowAdminCommands(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.Admin))
            return;

        var commands =
        """
        {Color1}/setrole: {Color2}Assigns a specific role to a player.
        {Color1}/setscore: {Color2}Sets the score of a player to a specified value.
        {Color1}/addscore: {Color2}Increases the player's score by a designated amount.
        {Color1}/addallscore: {Color2}Increases the score of all players by a specified amount.
        {Color1}/addcoins: {Color2}Increases the player's coins by a designated amount.
        {Color1}/addallcoins: {Color2}Grant a set number of coins to all players.
        {Color1}/goto: {Color2}Teleport to the position of a specified player.
        {Color1}/get: {Color2}Bring a specified player to your current position.
        {Color1}/ban: {Color2}Ban a player from the server.
        {Color1}/unban: {Color2}Remove a ban from a player, allowing them back on the server.
        {Color1}/bannedips: {Color2}View a list of IP addresses that are currently banned.

        {Color1}Use the '#' symbol at the start of your message to access the private admin chat.
        """;
        var content = Smart.Format(commands, new
        {
            Color1 = Color.Yellow,
            Color2 = Color.White,
        });
        var dialog = new MessageDialog(caption: "Admin Commands", content, "Close");
        dialogService.ShowAsync(player, dialog);
    }

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
