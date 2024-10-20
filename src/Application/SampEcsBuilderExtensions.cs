﻿namespace CTF.Application;

public static class ApplicationEcsBuilderExtensions
{
    public static IEcsBuilder RegisterMiddlewares(this IEcsBuilder builder)
    {
        builder
            .UseMiddleware<CommandLockMiddleware>(name: "OnPlayerCommandText");

        return builder;
    }
}
