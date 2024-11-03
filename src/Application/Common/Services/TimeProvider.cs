#if NET6_0
namespace CTF.Application.Common.Services;

public abstract class TimeProvider
{
    public static TimeProvider System { get; } = new SystemTimeProvider();
    public virtual DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
    private class SystemTimeProvider : TimeProvider
    {
        internal SystemTimeProvider() : base()
        {
        }
    }
}
#endif
