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
    private readonly TeamTextDrawRenderer _teamTextDrawRenderer;
    private readonly PlayerStatsRenderer _playerStatsRenderer;
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
        TeamTextDrawRenderer teamTextDrawRenderer,
        PlayerStatsRenderer playerStatsRenderer)
    {
        _serverService = serverService;
        _worldService = worldService;
        _timerService = timerService;
        _mapInfoService = mapInfoService;
        _mapTextDrawRenderer = mapTextDrawRenderer;
        _teamIconService = teamIconService;
        _teamPickupService = teamPickupService;
        _teamTextDrawRenderer = teamTextDrawRenderer;
        _playerStatsRenderer = playerStatsRenderer;
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
            _worldService.GameText(_loadTime.GameText, time: 99999999, style: 3);
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
        _teamPickupService.CreateFlagFromBasePosition(Team.Alpha);
        _teamPickupService.CreateFlagFromBasePosition(Team.Beta);
        _teamIconService.CreateFromBasePosition(Team.Alpha);
        _teamIconService.CreateFromBasePosition(Team.Beta);
        _serverService.SendRconCommand($"loadfs {nextMap.Name}");
        _serverService.SendRconCommand($"mapname {nextMap.Name}");
    }

    private void OnLoadedMap()
    {
        _isMapLoading = false;
        _worldService.GameText("_", 1000, 4);
        TimeLeft.Reset();
        CurrentMap currentMap = _mapInfoService.Read();
        string message = Smart.Format(Messages.MapSuccessfullyLoaded, new { currentMap.Name });
        _worldService.SendClientMessage(Color.Orange, message);
        IEnumerable<Player> players = AlphaBetaTeamPlayers.GetAll();
        foreach (Player player in players)
        {
            PlayerInfo playerInfo = player.GetInfo();
            playerInfo.StatsPerRound.ResetStats();
            playerInfo.SetTeam(TeamId.NoTeam);
            player.Team = (int)TeamId.NoTeam;
            player.ToggleControllable(true);
            player.Health = 100;
            player.RedirectToClassSelection();
            _playerStatsRenderer.HideTextDraw(player);
            _mapTextDrawRenderer.Hide(player);
            _teamTextDrawRenderer.Hide(player);
        }
        Team.Alpha.Reset();
        Team.Beta.Reset();
        _teamTextDrawRenderer.UpdateTeamScore(Team.Alpha);
        _teamTextDrawRenderer.UpdateTeamScore(Team.Beta);
        _teamTextDrawRenderer.UpdateTeamMembers(Team.Alpha);
        _teamTextDrawRenderer.UpdateTeamMembers(Team.Beta);
        _worldService.SetWeather(currentMap.Weather);
        _serverService.SetWorldTime(currentMap.WorldTime);
        _mapTextDrawRenderer.UpdateMapName(currentMap);
    }
}
