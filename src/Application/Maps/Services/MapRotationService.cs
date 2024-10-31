namespace CTF.Application.Maps.Services;

public class MapRotationService
{
    private readonly IServerService _serverService;
    private readonly IWorldService _worldService;
    private readonly ITimerService _timerService;
    private readonly MapInfoService _mapInfoService;
    private readonly MapTextDrawRenderer _mapTextDrawRenderer;
    private readonly TeamIconService _teamIconService;
    private readonly TeamPickupService _teamPickupService;
    private readonly TeamBalancer _teamBalancer;
    private readonly FlagAutoReturnTimer _flagAutoReturnTimer;
    private readonly TimeLeft _timeLeft;
    private readonly LoadTime _loadTime;
    private TimerReference _timerReference;
    private bool _isMapLoading;
    public TimeLeft TimeLeft => _timeLeft;
    public bool IsMapLoading() => _isMapLoading;

    public MapRotationService(
        IServerService serverService,
        IWorldService worldService,
        ITimerService timerService,
        MapInfoService mapInfoService,
        MapTextDrawRenderer mapTextDrawRenderer,
        TeamIconService teamIconService,
        TeamPickupService teamPickupService,
        TeamBalancer teamBalancer,
        FlagAutoReturnTimer flagAutoReturnTimer)
    {
        _serverService = serverService;
        _worldService = worldService;
        _timerService = timerService;
        _mapInfoService = mapInfoService;
        _mapTextDrawRenderer = mapTextDrawRenderer;
        _teamIconService = teamIconService;
        _teamPickupService = teamPickupService;
        _teamBalancer = teamBalancer;
        _flagAutoReturnTimer = flagAutoReturnTimer;
        _timeLeft = new TimeLeft();
        _loadTime = new LoadTime(OnLoadingMap, OnLoadedMap);
        _isMapLoading = false;
    }

    public void StartRotationTimer()
    {
        _timerReference ??= _timerService.Start(action: OnTimer, interval: TimeSpan.FromMilliseconds(1000));
    }

    public void StopRotationTimer() 
    {
        if (_timerReference is null)
            return;

        _timerService.Stop(_timerReference);
        _timerReference = default;
    }

    private void OnTimer(IServiceProvider serviceProvider)
    {
        if(_timeLeft.IsCompleted())
        {
            _loadTime.Decrease();
            _mapTextDrawRenderer.UpdateLoadTime(_loadTime);
            return;
        }

        _timeLeft.Decrease();
        _mapTextDrawRenderer.UpdateTimeLeft(_timeLeft);
    }

    private void OnLoadingMap()
    {
        _isMapLoading = true;
        if (Team.Alpha.IsWinner())
            _worldService.SendClientMessage(Color.Yellow, Messages.AlphaIsWinner);
        else if(Team.Beta.IsWinner())
            _worldService.SendClientMessage(Color.Yellow, Messages.BetaIsWinner);
        else
            _worldService.SendClientMessage(Color.Yellow, Messages.TiedTeams);

        CurrentMap currentMap = _mapInfoService.Read();
        _serverService.SendRconCommand($"unloadfs {currentMap.Name}");

        IEnumerable<Player> players = AlphaBetaTeamPlayers.GetAll();
        if (currentMap.Id == currentMap.NextMap.Id)
        {
            foreach (Player player in players)
            {
                player.Position = new Vector3(0, 0, 0);
                player.Angle = 0;
                player.Interior = 0;
                player.ToggleControllable(false);
            }
        }
        else
        {
            foreach (Player player in players)
                player.ToggleControllable(false);
        }

        string message = Smart.Format(Messages.NextMapWillBeLoadedSoon, new { currentMap.NextMap.Name });
        _worldService.SendClientMessage(Color.Orange, message);
        IMap nextMap = currentMap.NextMap;
        _mapInfoService.Load(nextMap);
        Team.Alpha.Flag.RemoveCarrier();
        Team.Beta.Flag.RemoveCarrier();
        _teamPickupService.DestroyAllPickups();
        _teamPickupService.CreateFlagFromBasePosition(Team.Alpha);
        _teamPickupService.CreateFlagFromBasePosition(Team.Beta);
        _teamIconService.DestroyAll();
        _teamIconService.CreateFromBasePosition(Team.Alpha);
        _teamIconService.CreateFromBasePosition(Team.Beta);
        _flagAutoReturnTimer.Stop(Team.Alpha);
        _flagAutoReturnTimer.Stop(Team.Beta);
        _serverService.SendRconCommand($"loadfs {nextMap.Name}");
        _serverService.SendRconCommand($"mapname {nextMap.Name}");
    }

    private void OnLoadedMap()
    {
        _isMapLoading = false;
        _mapTextDrawRenderer.HideLoadTimeForAll();
        TimeLeft.Reset();
        CurrentMap currentMap = _mapInfoService.Read();
        string message = Smart.Format(Messages.MapSuccessfullyLoaded, new { currentMap.Name });
        _worldService.SendClientMessage(Color.Orange, message);
        static void HandlePlayerAction(Player player, PlayerInfo playerInfo)
        {
            playerInfo.StatsPerRound.ResetStats();
            player.ToggleControllable(true);
            player.Health = 100;
            player.Color = playerInfo.Team.ColorHex;
            player.SetScore(0);
            player.Spawn();
        }
        _teamBalancer.Balance(action: HandlePlayerAction);
        _worldService.SetWeather(currentMap.Weather);
        _serverService.SetWorldTime(currentMap.WorldTime);
        _mapTextDrawRenderer.UpdateMapName(currentMap);
    }
}
