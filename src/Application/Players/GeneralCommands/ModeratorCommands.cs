namespace CTF.Application.Players.GeneralCommands;

public class ModeratorCommands(IWorldService worldService) : ISystem
{
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
