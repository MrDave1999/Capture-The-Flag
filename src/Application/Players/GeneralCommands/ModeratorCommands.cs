namespace CTF.Application.Players.GeneralCommands;

public class ModeratorCommands(IWorldService worldService) : ISystem
{
    [PlayerCommand("cmdsmoderator")]
    public void ShowModeratorCommands(Player player, IDialogService dialogService)
    {
        if (player.HasLowerRoleThan(RoleId.Moderator))
            return;

        var commands =
        """
        {Color1}/maps: {Color2}Displays a list of available maps in the game.
        {Color1}/settimeleft: {Color2}Sets the remaining time for the current game session.
        {Color1}/startrt: {Color2}Starts the rotation timer for the current map.
        {Color1}/stoprt: {Color2}Stops the rotation timer for the current map.
        {Color1}/kick: {Color2}Kicks a player from the game.
        {Color1}/warn: {Color2}Issues a warning to a player for inappropriate behavior.
        {Color1}/setspawn: {Color2}Sets a new spawn point for players in the game.
        {Color1}/addhealth: {Color2}Adds health to a specified player.
        {Color1}/addallhealth: {Color2}Restores health to all players in the game.
        {Color1}/addarmour: {Color2}Grants armour to a specified player.
        {Color1}/addallarmour: {Color2}Gives armour to all players in the game.
        {Color1}/clearallchat: {Color2}Clears all messages from the chat.

        {Color1}Use the '&' symbol at the start of your message to access the private moderator chat.
        """;
        var content = Smart.Format(commands, new
        {
            Color1 = Color.Yellow,
            Color2 = Color.White,
        });
        var dialog = new MessageDialog(caption: "Moderator Commands", content, "Close");
        dialogService.ShowAsync(player, dialog);
    }

    [PlayerCommand("kick")]
    public void Kick(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        string reason)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Moderator))
            return;

        if (currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        var message = Smart.Format(Messages.SuccessfullyKicked, new
        {
            CurrentPlayer = currentPlayer.Name,
            TargetPlayer = targetPlayer.Name,
            Reason = reason
        });
        worldService.SendClientMessage(Color.Red, message);
        targetPlayer.Kick();
    }

    [PlayerCommand("setspawn")]
    public void SetSpawn(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Moderator))
            return;

        if (targetPlayer.IsUnauthenticated())
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.UnauthenticatedPlayer);
            return;
        }

        if (targetPlayer.IsInClassSelection())
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsInClassSelection);
            return;
        }

        if (targetPlayer.State == PlayerState.Spectating)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerInSpectatorMode);
            return;
        }

        var message = Smart.Format(Messages.SetSpawnToPlayer, new { PlayerName = targetPlayer.Name });
        currentPlayer.SendClientMessage(Color.Yellow, message);
        targetPlayer.Spawn();
    }

    [PlayerCommand("clearallchat")]
    public void ClearAllChat(Player currentPlayer)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Moderator))
            return;

        for (int i = 0; i < 200; i++)
        {
            worldService.SendClientMessage(" ");
        }
    }

    [PlayerCommand("warn")]
    public void Warn(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        string reason)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Moderator))
            return;

        if (currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        var warningsComponent = targetPlayer.GetComponent<WarningsComponent>();
        warningsComponent.Value++;

        var message = Smart.Format(Messages.WarningSuccessfullyGiven, new
        {
            CurrentPlayer = currentPlayer.Name,
            TargetPlayer = targetPlayer.Name,
            WarningsNumber = warningsComponent.Value,
            Reason = reason
        });
        worldService.SendClientMessage(Color.Yellow, message);
        if (warningsComponent.Value == 3)
        {
            targetPlayer.Kick();
        }
    }

    [Event]
    public void OnPlayerConnect(Player player)
        => player.AddComponent<WarningsComponent>();

    private class WarningsComponent : Component
    {
        public int Value { get; set; }
    }
}
