namespace CTF.Application.Players.AFK;

public class PlayerPauseSystem(
    ITimerService timerService,
    IEntityManager entityManager,
    TimeProvider timeProvider) : ISystem
{
    /// <summary>
    /// Represents the minimum amount of time (in ticks) required for the player to be considered paused.
    /// </summary>
    private readonly long _minPauseTimeTicks = TimeSpan.FromMilliseconds(4000).Ticks;
    private readonly List<PlayerDataComponent> _playerDataComponents = new(capacity: 32);
    public delegate void PauseEventHandler(Player player, bool pauseState);
    public event PauseEventHandler PauseEvent;

    [Event]
    public void OnPlayerConnect(Player player)
    {
        var createdComponent = player.AddComponent<PlayerDataComponent>(player);
        _playerDataComponents.Add(createdComponent);
    }

    [Event]
    public void OnPlayerDisconnect(PlayerDataComponent playerDataComponent, DisconnectReason _) 
    {
        _playerDataComponents.Remove(playerDataComponent);
    }

    [Event]
    public void OnPlayerUpdate(PlayerDataComponent playerDataComponent) 
    {
        playerDataComponent.LastUpdateTick = timeProvider.GetUtcNow().Ticks;
    }

    [Event]
    public void OnGameModeInit()
    {
        TimeSpan interval = TimeSpan.FromMilliseconds(600);
        timerService.Start(CheckPauseStatus, interval);
    }

    private void CheckPauseStatus(IServiceProvider serviceProvider)
    {
        int count = _playerDataComponents.Count;
        for (int i = 0; i < count; i++)
        {
            PlayerDataComponent playerDataComponent = _playerDataComponents[i];
            if (playerDataComponent.State == PlayerState.None)
                continue;

            if (playerDataComponent.State == PlayerState.Wasted)
                continue;

            long currentTicks = timeProvider.GetUtcNow().Ticks;
            long elapsedTicks = currentTicks - playerDataComponent.LastUpdateTick;
            if (!playerDataComponent.IsPaused && elapsedTicks >= _minPauseTimeTicks)
            {
                Player player = entityManager.GetComponent<Player>(playerDataComponent.Entity);
                playerDataComponent.IsPaused = true;
                Console.WriteLine($"[CTF:INFO] {player.Name} went into pause mode");
                PauseEvent?.Invoke(player, playerDataComponent.IsPaused);
            }
            else if (playerDataComponent.IsPaused && elapsedTicks < _minPauseTimeTicks)
            {
                Player player = entityManager.GetComponent<Player>(playerDataComponent.Entity);
                playerDataComponent.IsPaused = false;
                Console.WriteLine($"[CTF:INFO] {player.Name} exited pause mode");
                PauseEvent?.Invoke(player, playerDataComponent.IsPaused);
            }
        }
    }
}
