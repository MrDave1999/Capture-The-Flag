namespace CTF.Application.Common.Extensions;

public static class DateTimeExtensions
{
    public static string GetDateWithStandardFormat(this DateTime dateTime)
        => dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
}
