namespace CTF.Application.Teams.Flags;

public enum FlagStatus
{
    /// <summary>
    /// Indicates that the flag is on its base.
    /// </summary>
    InitialPosition,

    /// <summary>
    /// Indicates that a player has captured the opposing team's flag from their base.
    /// </summary>
    Captured,

    /// <summary>
    /// Indicates that a player has returned the flag to their team's base.
    /// </summary>
    Returned,

    /// <summary>
    /// Indicates that a player has taken the flag from a position other than the base.
    /// </summary>
    Taken,

    /// <summary>
    /// Indicates that a player has captured the opposing team's flag and brought it back to their own base.
    /// </summary>
    Brought,

    /// <summary>
    /// Indicates that a player has dropped the opposing team's flag.
    /// </summary>
    Dropped
}
