namespace CTF.Application.Players;

/// <summary>
/// Represents the reuse times for different commands in the game.
/// </summary>
/// <remarks>The times are expressed in minutes.</remarks>
public class CommandCooldowns
{
    /// <summary>
    /// Gets the reuse time for the health command in minutes.
    /// </summary>
    public int Health { get; init; } = 3;

    /// <summary>
    /// Gets the reuse time for the armour command in minutes.
    /// </summary>
    public int Armour { get; init; } = 3;

    /// <summary>
    /// Gets the reuse time for the coins command in minutes.
    /// </summary>
    public int Coins { get; init; } = 3;
}
