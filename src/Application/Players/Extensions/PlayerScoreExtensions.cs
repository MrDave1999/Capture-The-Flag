namespace CTF.Application.Players.Extensions;

public static class PlayerScoreExtensions
{
    /// <summary>
    /// Increments the player's score by one.
    /// </summary>
    /// <param name="player">The player whose score will be incremented.</param>
    /// <remarks>
    /// This method does not perform any validation. Ensure that the player's score
    /// can be incremented safely, as this may affect game logic.
    /// </remarks>
    public static void AddScore(this Player player)
        => player.Score++;

    /// <summary>
    /// Adds the specified score value to the player's current score.
    /// </summary>
    /// <param name="player">The player whose score will be updated.</param>
    /// <param name="value">The amount to add to the player's score. Must be non-negative.</param>
    /// <returns>
    /// A <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    /// <remarks>
    /// If the value is negative, the operation will fail, and an appropriate error message will be returned.
    /// </remarks>
    public static Result AddScore(this Player player, int value)
    {
        if (value < 0)
            return Result.Failure(Messages.ValueCannotBeNegative);

        player.Score += value;
        return Result.Success();
    }

    /// <summary>
    /// Sets the player's score to the specified value.
    /// </summary>
    /// <param name="player">The player whose score will be set.</param>
    /// <param name="value">The new score value. Must be non-negative.</param>
    /// <returns>
    /// A <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    /// <remarks>
    /// If the value is negative, the operation will fail, and an appropriate error message will be returned.
    /// </remarks>
    public static Result SetScore(this Player player, int value)
    {
        if (value < 0)
            return Result.Failure(Messages.ValueCannotBeNegative);

        player.Score = value;
        return Result.Success();
    }
}
