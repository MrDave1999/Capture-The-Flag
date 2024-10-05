namespace CTF.Application.Players.Vitalities;

public class HealthSystem(
    IWorldService worldService,
    IEntityManager entityManager) : ISystem
{
    [PlayerCommand("addhealth")]
    public void AddHealthToPlayer(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        float amount)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Moderator))
            return;

        Result<Vitality> result = Vitality.Create(amount);
        if(result.IsFailed)
        {
            currentPlayer.SendClientMessage(Color.Red, result.Message);
            return;
        }

        {
            var message = Smart.Format(Messages.AddHealthToPlayer, new
            {
                PlayerName = targetPlayer.Name,
                Health = amount
            });
            currentPlayer.SendClientMessage(Color.Yellow, message);
        }

        {
            var message = Smart.Format(Messages.ReceiveHealthFromPlayer, new
            {
                PlayerName = currentPlayer.Name,
                Health = amount
            });
            targetPlayer.SendClientMessage(Color.Yellow, message);
            targetPlayer.AddHealth(amount);
        }
    }

    [PlayerCommand("addallhealth")]
    public void AddHealthToAllPlayers(Player currentPlayer, float amount)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Moderator))
            return;

        Result<Vitality> result = Vitality.Create(amount);
        if (result.IsFailed)
        {
            currentPlayer.SendClientMessage(Color.Red, result.Message);
            return;
        }

        IEnumerable<Player> players = entityManager.GetComponents<Player>();
        foreach (Player targetPlayer in players) 
        { 
            targetPlayer.AddHealth(amount);
        }

        var message = Smart.Format(Messages.AddHealthToAllPlayers, new
        {
            PlayerName = currentPlayer.Name,
            Health = amount
        });
        worldService.SendClientMessage(Color.Yellow, message);
    }
}
