namespace CTF.Application.Teams.Services;

public class TeamPickupService
{
    private readonly CurrentMap _currentMap;
    private readonly IWorldService _worldService;
    private Pickup _redFlagPickup;
    private Pickup _blueFlagPickup;
    private Pickup _alphaPickupInfo;
    private Pickup _betaPickupInfo;

    public TeamPickupService(MapInfoService mapInfoService, IWorldService worldService)
    {
        _worldService = worldService;
        _currentMap = mapInfoService.Read();
        CreateFlagFromBasePosition(Team.Alpha);
        CreateFlagFromBasePosition(Team.Beta);
    }

    public void CreateFlagFromBasePosition(Team team)
    {
        ArgumentNullException.ThrowIfNull(team);
        if (team.Id == TeamId.Alpha)
        {
            CreateFlagFromVector3(team, _currentMap.FlagLocations.Red);
        }
        else if(team.Id == TeamId.Beta) 
        {
            CreateFlagFromVector3(team, _currentMap.FlagLocations.Blue);
        }
    }

    public void CreateFlagFromVector3(Team team, Vector3 position) 
    {
        ArgumentNullException.ThrowIfNull(team);
        DestroyFlag(team);
        if (team.Id == TeamId.Alpha)
        {
            _redFlagPickup = _worldService.CreatePickup(
                model: (int)Team.Alpha.Flag.Model,
                type: PickupType.ScriptedActionsOnlyEveryFewSeconds,
                position
            );
        }
        else if (team.Id == TeamId.Beta)
        {
            _blueFlagPickup = _worldService.CreatePickup(
               model: (int)Team.Beta.Flag.Model,
               type: PickupType.ScriptedActionsOnlyEveryFewSeconds,
               position
            );
        }
    }

    public void DestroyFlag(Team team) 
    {
        ArgumentNullException.ThrowIfNull(team);
        if(team.Id == TeamId.Alpha) 
        {
            _redFlagPickup?.Destroy();
            _redFlagPickup = default;
        }
        else if(team.Id == TeamId.Beta)
        {
            _blueFlagPickup?.Destroy();
            _blueFlagPickup = default;
        }
    }

    public void DestroyFlags()
    {
        DestroyFlag(Team.Alpha);
        DestroyFlag(Team.Beta);
    }

    public void CreatePickupWithInfo(Team team)
    {
        ArgumentNullException.ThrowIfNull(team);
        DestroyPickupWithInfo(team);
        if (team.Id == TeamId.Alpha)
        {
            _alphaPickupInfo = _worldService.CreatePickup(
                model: 1239,
                type: PickupType.ScriptedActionsOnlyEveryFewSeconds,
                position: _currentMap.FlagLocations.Red
            );
        }
        else if(team.Id == TeamId.Beta)
        {
            _betaPickupInfo = _worldService.CreatePickup(
                model: 1239,
                type: PickupType.ScriptedActionsOnlyEveryFewSeconds,
                position: _currentMap.FlagLocations.Blue
            );
        }
    }

    public void DestroyPickupWithInfo(Team team)
    {
        ArgumentNullException.ThrowIfNull(team);
        if (team.Id == TeamId.Alpha)
        {
            _alphaPickupInfo?.Destroy();
            _alphaPickupInfo = default;
        }
        else if (team.Id == TeamId.Beta)
        {
            _betaPickupInfo?.Destroy();
            _betaPickupInfo = default;
        }
    }

    public void DestroyAllPickups()
    {
        DestroyPickupWithInfo(Team.Alpha);
        DestroyPickupWithInfo(Team.Beta);
        DestroyFlags();
    }
}
