namespace CTF.Application.Players.Extensions;

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
    /// when the player is not assigned the <see cref="AccountComponent"/> component.
    /// </exception>
    public static PlayerInfo GetInfo(this Player player)
    {
        AccountComponent accountComponent = player.GetComponent<AccountComponent>();
        return accountComponent is null ?
            throw new InvalidOperationException($"The player is not assigned the {nameof(AccountComponent)} component") :
            accountComponent.PlayerInfo;
    }
}
