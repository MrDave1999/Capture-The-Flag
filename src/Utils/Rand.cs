namespace CaptureTheFlag.Utils;

public static class Rand
{
    private static readonly Random random = new Random();
    public static int Next(int max) => random.Next(max);

    public static void Shuffle<T>(T[]array)
    {
        T aux;
        for (int i = array.Length - 1, index; i > 0; --i)
        {
            index = random.Next(i + 1);
            aux = array[i];
            array[i] = array[index];
            array[index] = aux;
        }
    }
}
