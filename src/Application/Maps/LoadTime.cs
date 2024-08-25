namespace CTF.Application.Maps;

/// <summary>
/// Represents the total wait time for the new map to load.
/// </summary>
public class LoadTime
{
    private readonly Action _onLoadingMap;
    private readonly Action _onLoadedMap;
    private int _interval = MaxLoadTime;
    public const int MaxLoadTime = 6;

    /// <summary>
    /// Displays the load time in the game.
    /// </summary>
    public string GameText { get; private set; } = string.Empty;

    /// <summary>
    /// Represents the interval in seconds.
    /// </summary>
    public int Interval => _interval;

    public LoadTime(Action onLoadingMap, Action onLoadedMap)
    {
        ArgumentNullException.ThrowIfNull(onLoadingMap);
        ArgumentNullException.ThrowIfNull(onLoadedMap);
        _onLoadingMap = onLoadingMap;
        _onLoadedMap = onLoadedMap;
    }

    /// <summary>
    /// Reduces the load time until it reaches zero.
    /// </summary>
    public void Decrease()
    {
        if (_interval == 0)
        {
            Reset();
            _onLoadedMap();
            return;
        }

        if (_interval == MaxLoadTime)
        {
            _onLoadingMap();
        }

        _interval--;
        UpdateGameText();
    }

    private void UpdateGameText() => GameText = $"Loading map... ({_interval})";
    private void Reset()
    {
        _interval = MaxLoadTime;
        GameText = string.Empty;
    }
}
