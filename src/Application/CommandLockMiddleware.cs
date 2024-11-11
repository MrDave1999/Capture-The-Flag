namespace CTF.Application;

public class CommandLockMiddleware(
    IEntityManager entityManager, 
    EventDelegate next,
    MapRotationService mapRotationService)
{
    public object Invoke(EventContext context)
    {
        int playerId = (int)context.Arguments[0];
        EntityId entity = SampEntities.GetPlayerId(playerId);
        Player player = entityManager.GetComponent<Player>(entity);

        if(player.IsUnauthenticated())
        {
            player.SendClientMessage(Color.Red, Messages.LoginOrRegisterToContinue);
            return null;
        }

        if (player.IsInClassSelection())
        {
            player.SendClientMessage(Color.Red, Messages.CommandLockClassSelection);
            return null;
        }

        if(mapRotationService.IsMapLoading())
        {
            player.SendClientMessage(Color.Red, Messages.CommandLockMapLoading);
            return null;
        }

        return next(context);
    }
}
