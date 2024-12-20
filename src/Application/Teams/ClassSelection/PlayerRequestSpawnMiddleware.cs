namespace CTF.Application.Teams.ClassSelection;

public class PlayerRequestSpawnMiddleware(
    IEntityManager entityManager,
    EventDelegate next,
    MapRotationService mapRotationService)
{
    public object Invoke(EventContext context)
    {
        int playerId = (int)context.Arguments[0];
        EntityId entity = SampEntities.GetPlayerId(playerId);
        Player player = entityManager.GetComponent<Player>(entity);
        if (player.IsUnauthenticated())
        {
            player.SendClientMessage(Color.Red, Messages.LoginOrRegisterToContinue);
            return false;
        }

        if (mapRotationService.IsMapLoading())
        {
            player.SendClientMessage(Color.Red, Messages.MapIsLoading);
            return false;
        }

        Team selectedTeam = player.Team == (int)TeamId.Alpha ? Team.Alpha : Team.Beta;
        if (selectedTeam.IsFull())
        {
            string gameText = selectedTeam.GetAvailabilityMessage();
            player.GameText(gameText, 999999999, 3);
            return false;
        }

        return next(context);
    }
}
