namespace CTF.Application.Teams.Flags;

/// <summary>
/// Represents an event related to the flag in the game.
/// </summary>
public interface IFlagEvent
{
    /// <summary>
    /// Gets the current status of the flag associated with the event.
    /// </summary>
    FlagStatus FlagStatus { get; }

    /// <summary>
    /// Handles the event when the flag is involved, updating the game state accordingly.
    /// </summary>
    /// <param name="team">The team associated with the event.</param>
    /// <param name="player">The player who triggered the event.</param>
    void Handle(Team team, Player player);
}
