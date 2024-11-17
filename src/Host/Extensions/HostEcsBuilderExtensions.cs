namespace CTF.Host.Extensions;

public static class HostEcsBuilderExtensions
{
    public static IEcsBuilder EnableExceptionHandler(this IEcsBuilder builder)
    {
        string[] events =
        [
            "OnGameModeInit",
            "OnGameModeExit",
            "OnPlayerCommandText",
            "OnPlayerConnect",
            "OnPlayerDisconnect",
            "OnDialogResponse",
            "OnPlayerText",
            "OnPlayerUpdate",
            "OnPlayerDeath",
            "OnPlayerTakeDamage",
            "OnPlayerGiveDamage",
            "OnRconLoginAttempt",
            "OnRconCommand",
            "OnPlayerKeyStateChange",
            "OnPlayerPickUpPickup",
            "OnPlayerSpawn",
            "OnPlayerRequestClass",
            "OnPlayerRequestSpawn",
            "OnPlayerPauseStateChange"
        ];

        foreach (string @event in events)
        {
            builder.UseMiddleware<GlobalExceptionHandler>(@event);
        }

        return builder;
    }

    public static IEcsBuilder EnableYsfEvents(this IEcsBuilder builder) 
    {
        builder
            .EnableEvent<int, bool>("OnPlayerPauseStateChange");

        builder.UseMiddleware<PlayerPauseStateChangeMiddleware>("OnPlayerPauseStateChange");
        return builder;
    }
}
