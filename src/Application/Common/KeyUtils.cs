namespace CTF.Application.Common;

/// <summary>
/// Contains methods to check for keypresses.
/// </summary>
public static class KeyUtils
{
    /// <summary>
    /// Checks if <see cref="Keys" /> have been pressed.
    /// </summary>
    /// <param name="newKeys">
    /// New <see cref="Keys" />.
    /// </param>
    /// <param name="oldKeys">
    /// Old <see cref="Keys" />.
    /// </param>
    /// <param name="keys">
    /// The <see cref="Keys" /> to check for.
    /// </param>
    /// <returns>
    /// Whether the <see cref="Keys" /> have been pressed.
    /// </returns>
    public static bool HasPressed(Keys newKeys, Keys oldKeys, Keys keys)
        => newKeys.HasFlag(keys) && !oldKeys.HasFlag(keys);

    /// <summary>
    /// Checks if <see cref="Keys" /> have been released.
    /// </summary>
    /// <param name="newKeys">
    /// New <see cref="Keys" />.
    /// </param>
    /// <param name="oldKeys">
    /// Old <see cref="Keys" />.
    /// </param>
    /// <param name="keys">
    /// The <see cref="Keys" /> to check for.
    /// </param>
    /// <returns>
    /// Whether the <see cref="Keys" /> have been released.
    /// </returns>
    public static bool HasReleased(Keys newKeys, Keys oldKeys, Keys keys)
        => !newKeys.HasFlag(keys) && oldKeys.HasFlag(keys);
}
