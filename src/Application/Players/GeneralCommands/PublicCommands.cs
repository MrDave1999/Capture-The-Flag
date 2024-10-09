namespace CTF.Application.Players.GeneralCommands;

public class PublicCommands(
    IEntityManager entityManager,
    IDialogService dialogService) : ISystem
{
    [PlayerCommand("cmds")]
    public void ShowCommands(Player player)
    {
        var commands =
        """
        {Color1}/help: {Color2}Display an introduction to the Capture The Flag game mode.
        {Color1}/credits: {Color2}Show credits for the game and contributors.
        {Color1}/ranks: {Color2}List the different player ranks and their requirements.
        {Color1}/mystats: {Color2}Display the statistics of the current player.
        {Color1}/stats: {Color2}Show the statistics of a specified player.
        {Color1}/tstats: {Color2}Display the statistics of the teams (Alpha and Beta).
        {Color1}/changepass: {Color2}Change your account password.
        {Color1}/changename: {Color2}Change your account name.
        {Color1}/skin: {Color2}Change your character's skin.
        {Color1}/weapons: {Color2}Display a list of available weapons
        {Color1}/pack: {Color2}Display your current weapons package.
        {Color1}/combos: {Color2}Display a list of available combos and their benefits.
        {Color1}/team: {Color2}Switch to a different team.
        {Color1}/scoreboard: {Color2}Show the current scoreboard with player scores.
        {Color1}/kill: {Color2}Eliminate your character for respawn purposes.
        {Color1}/re: {Color2}Reset the statistics of the current player.
        {Color1}/admins: {Color2}List the current server administrators.
        {Color1}/vips: {Color2}Display the list of VIP players.
        {Color1}/report: {Color2}Report a player for inappropriate behavior.
        {Color1}/spec: {Color2}Spectate a specific player in the game.
        {Color1}/class: {Color2}Redirect to the class selection menu and enter AFK mode.
        {Color1}/cmdsvip: {Color2}Display a list of commands available to VIP players.
        {Color1}/cmdsadmin: {Color2}Show the commands accessible to server administrators.
        {Color1}/cmdsmoderator: {Color2}Show the commands accessible to server moderators.

        {Color1}Use the '!' symbol at the start of your message to access the private team chat.
        """;
        var content = Smart.Format(commands, new
        {
            Color1 = Color.Yellow,
            Color2 = Color.White
        });
        var dialog = new MessageDialog(caption: "Commands", content, "Close");
        dialogService.ShowAsync(player, dialog);
    }

    [PlayerCommand("help")]
    public void ShowHelp(Player player)
    {
        var help =
        """
        {Color1}This is a capture the flag game mode for SA-MP (San Andreas Multiplayer).
        {Color2}There are 2 flags on the map, one for each team. 
        Players need to capture the enemy's flag and bring it back to their own one.
        {Color1}Gameplay:{Color2}
        The Alpha team plays against the Beta team. 
        The aim is to carry the enemy's flag to the spawn of the own flag. 
        The own flag needs to be at the spawn to score. 
        So you have to conquer the opponent's flag and defend your own team's one at the same time. 
        It's necassary for the whole team to work together tactically to win.
        """;
        var content = Smart.Format(help, new
        {
            Color1 = Color.Yellow,
            Color2 = Color.White
        });
        var dialog = new MessageDialog(caption: "Help", content, "Close");
        dialogService.ShowAsync(player, dialog);
    }

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
            currentPlayer.SendClientMessage(Color.Red, Messages.NoAdminsConnected);
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
            currentPlayer.SendClientMessage(Color.Red, Messages.NoVIPsConnected);
            return;
        }
        var dialog = new ListDialog(caption: $"VIPs: {count}", "Close", "");
        foreach (PlayerInfo playerInfo in vips)
        {
            dialog.Add(playerInfo.Name);
        }
        dialogService.ShowAsync(currentPlayer, dialog);
    }

    [PlayerCommand("report")]
    public void ReportPlayer(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        string reason)
    {
        if (currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        IEnumerable<Player> admins = entityManager
            .GetComponents<Player>()
            .Where(player => player.GetInfo().RoleId >= RoleId.Moderator);

        if (!admins.Any())
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.NoAdminsConnected);
            return;
        }

        var message = Smart.Format(Messages.ReportToAnotherPlayer, new
        {
            CurrentPlayer = currentPlayer.Name,
            TargetPlayer = targetPlayer.Name,
            Reason = reason
        });
        foreach (Player player in admins)
        {
            player.SendClientMessage(Color.Red, message);
        }
        currentPlayer.SendClientMessage(Color.Yellow, Messages.ReportSuccessfullySent);
        currentPlayer.PlaySound(1058);
    }

    [PlayerCommand("spec")]
    public void EnableSpectatorMode(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        TeamTextDrawRenderer teamTextDrawRenderer)
    {
        if (currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        if (targetPlayer.IsInClassSelection())
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsInClassSelection);
            return;
        }

        if (currentPlayer.GetInfo().HasCapturedFlag())
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.HasCapturedFlag);
            return;
        }

        if (currentPlayer.Health < 85)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerWithInsufficientHealth);
            return;
        }

        Team removedTeam = currentPlayer.RemoveFromCurrentTeam();
        teamTextDrawRenderer.UpdateTeamMembers(removedTeam);
        currentPlayer.ToggleSpectating(true);
        currentPlayer.SpectatePlayer(targetPlayer);
        currentPlayer.SendClientMessage(Color.Yellow, Messages.ExitSpectatorMode);
    }
}
