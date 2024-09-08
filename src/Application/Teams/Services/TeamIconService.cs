﻿namespace CTF.Application.Teams.Services;

public class TeamIconService
{
    private readonly CurrentMap _currentMap;
    private readonly IStreamerService _streamerService;
    private DynamicMapIcon _redMapIcon;
    private DynamicMapIcon _blueMapIcon;

    public TeamIconService(MapInfoService mapInfoService, IStreamerService streamerService)
    {
        _streamerService = streamerService;
        _currentMap = mapInfoService.Read();
        CreateFromBasePosition(Team.Alpha);
        CreateFromBasePosition(Team.Beta);
    }

    public void CreateFromBasePosition(Team team)
    {
        ArgumentNullException.ThrowIfNull(team);
        if(team.Id == TeamId.Alpha)
        {
            CreateFromVector3(team, _currentMap.FlagLocations.Red);
        }
        else if(team.Id == TeamId.Beta) 
        {
            CreateFromVector3(team, _currentMap.FlagLocations.Blue);
        }
    }

    public void CreateFromVector3(Team team, Vector3 position) 
    {
        ArgumentNullException.ThrowIfNull(team);
        Destroy(team);
        if (team.Id == TeamId.Alpha)
        {
            _redMapIcon = _streamerService.CreateDynamicMapIcon(
                position: position,
                mapIcon: (MapIcon)Team.Alpha.Flag.Icon,
                streamDistance: 5000f,
                interior: _currentMap.Interior,
                color: Team.Alpha.Flag.ColorHex
            );
        }
        else if(team.Id == TeamId.Beta)
        {
            _blueMapIcon = _streamerService.CreateDynamicMapIcon(
                position: position,
                mapIcon: (MapIcon)Team.Beta.Flag.Icon,
                streamDistance: 5000f,
                interior: _currentMap.Interior,
                color: Team.Beta.Flag.ColorHex
            );
        }
    }

    public void Destroy(Team team)
    {
        ArgumentNullException.ThrowIfNull(team);
        if(team.Id == TeamId.Alpha) 
        {
            _redMapIcon?.Destroy();
            _redMapIcon = default;
        }
        else if (team.Id == TeamId.Beta)
        {
            _blueMapIcon?.Destroy();
            _blueMapIcon = default;
        }
    }

    public void DestroyAll()
    {
        Destroy(Team.Alpha);
        Destroy(Team.Beta);
    }
}
