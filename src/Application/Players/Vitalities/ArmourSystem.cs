namespace CTF.Application.Players.Vitalities;

public class ArmourSystem(
    IWorldService worldService,
    IEntityManager entityManager) : ISystem
{
    [PlayerCommand("addarmour")]
    public void AddArmourToPlayer(
        Player currentPlayer,
        [CommandParameter(Name = "playerId")]Player targetPlayer,
        float amount)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Moderator))
            return;

        Result<Vitality> result = Vitality.Create(amount);
        if (result.IsFailed)
        {
            currentPlayer.SendClientMessage(Color.Red, result.Message);
            return;
        }

        {
            var message = Smart.Format(Messages.AddArmourToPlayer, new
            {
                PlayerName = targetPlayer.Name,
                Armour = amount
            });
            currentPlayer.SendClientMessage(Color.Yellow, message);
        }

        {
            var message = Smart.Format(Messages.ReceiveArmourFromPlayer, new
            {
                PlayerName = currentPlayer.Name,
                Armour = amount
            });
            targetPlayer.SendClientMessage(Color.Yellow, message);
            targetPlayer.AddArmour(amount);
        }
    }

    [PlayerCommand("addallarmour")]
    public void AddArmourToAllPlayers(Player currentPlayer, float amount)
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
            targetPlayer.AddArmour(amount);
        }

        var message = Smart.Format(Messages.AddArmourToAllPlayers, new
        {
            PlayerName = currentPlayer.Name,
            Armour = amount
        });
        worldService.SendClientMessage(Color.Yellow, message);
    }
}
