namespace CTF.Application.Common.Services;

/// <summary>
/// Represents the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
/// </summary>
/// <remarks>
/// See <see href="https://en.wikipedia.org/wiki/Unix_time">Unix Timestamp</see>.
/// </remarks>
public class UnixTimeSeconds(TimeProvider timeProvider)
{
    /// <summary>
    /// Gets the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
    /// </summary>
    public long Value => timeProvider.GetUtcNow().ToUnixTimeSeconds();
}
