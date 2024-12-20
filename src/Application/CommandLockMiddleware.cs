﻿namespace CTF.Application;

public class CommandLockMiddleware(
    IEntityManager entityManager, 
    EventDelegate next,
    MapRotationService mapRotationService)
{
    /// <summary>
    /// Invokes the middleware logic to lock player commands if certain conditions are met.
    /// </summary>
    /// <param name="context">Contains context information about the fired event.</param>
    /// <returns>
    /// <see langword="null"/> if any condition is met to block the command.
    /// Otherwise, it proceeds to the next middleware or action.
    /// </returns>
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
