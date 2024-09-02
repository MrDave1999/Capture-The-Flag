namespace Persistence.InMemory;

internal class PlayerIdValueGenerator
{
    private PlayerIdValueGenerator() { }
    private int _current = 0;
    public static PlayerIdValueGenerator Instance { get; } = new();
    public int Next() => _current++;
    public int Reset() => _current = 0;
}
