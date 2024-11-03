#if NET6_0
namespace CTF.Application.Common.Extensions;

public static class RandomExtensions
{
    public static void Shuffle<T>(this Random random, T[] values)
        => random.Shuffle(values.AsSpan());

    private static void Shuffle<T>(this Random random, Span<T> values)
    {
        int n = values.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int j = random.Next(i, n);
            if (j != i)
            {
                T temp = values[i];
                values[i] = values[j];
                values[j] = temp;
            }
        }
    }
}
#endif
