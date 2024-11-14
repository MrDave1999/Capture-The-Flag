namespace CTF.Host.Middlewares;

public class PlayerPauseStateChangeMiddleware(EventDelegate next)
{
    public object Invoke(EventContext context, IEntityManager entityManager)
    {
        var playerEntity = SampEntities.GetPlayerId((int)context.Arguments[0]);

        if (!entityManager.Exists(playerEntity))
            return null;

        context.Arguments[0] = playerEntity;
        return next(context);
    }
}
