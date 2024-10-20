﻿namespace CTF.Application.Players.Extensions;

public static class PlayerExtensions
{
    /// <summary>
    /// Gets the information from a player.
    /// </summary>
    /// <param name="player">The current player.</param>
    /// <returns>
    /// An instance of type <see cref="PlayerInfo"/>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// when the <see cref="AccountComponent"/> component is not attached to the player.
    /// </exception>
    public static PlayerInfo GetInfo(this Player player)
    {
        AccountComponent accountComponent = player.GetComponent<AccountComponent>();
        return accountComponent is null ?
            throw new InvalidOperationException($"The '{nameof(AccountComponent)}' component is not attached to the player") :
            accountComponent.PlayerInfo;
    }

    /// <summary>
    /// Checks if the player is unauthenticated.
    /// </summary>
    /// <param name="player">
    /// The player to check for authentication status.
    /// </param>
    /// <returns>
    /// <c>true</c> if the player is unauthenticated; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// when the <see cref="AccountComponent"/> component is not attached to the player.
    /// </exception>
    public static bool IsUnauthenticated(this Player player)
    {
        AccountComponent accountComponent = player.GetComponent<AccountComponent>();
        return accountComponent is null ?
            throw new InvalidOperationException($"The '{nameof(AccountComponent)}' component is not attached to the player") :
            accountComponent.IsUnauthenticated;
    }
}
