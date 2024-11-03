namespace CTF.Application.Common.Extensions;

public static class Int32Extensions
{
    public static bool IsEvenInteger(this int value) => (value & 1) == 0;
}
