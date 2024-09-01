namespace CTF.Application.Common.Services;

/// <summary>
/// Represents the current server time.
/// </summary>
public class ServerTimeService
{
    /// <summary>
    /// Gets the current server time.
    /// </summary>
    /// <returns>
    /// The method itself returns a <see href="https://en.wikipedia.org/wiki/Unix_time">Unix Timestamp</see>.
    /// </returns>
    public virtual int GetTime()
        => ServerTimeNativeObject.Instance.gettime(out _, out _, out _);

    /// <summary>
    /// Gets the current server time.
    /// </summary>
    /// <param name="hour">
    /// The variable to store the hour in, passed by reference.
    /// </param>
    /// <param name="minute">
    /// The variable to store the minute in, passed by reference.
    /// </param>
    /// <param name="second">
    /// The variable to store the seconds in, passed by reference.
    /// </param>
    /// <returns>
    /// The method itself returns a <see href="https://en.wikipedia.org/wiki/Unix_time">Unix Timestamp</see>.
    /// </returns>
    public virtual int GetTime(out int hour, out int minute, out int second)
        => ServerTimeNativeObject.Instance.gettime(out hour, out minute, out second);
}
