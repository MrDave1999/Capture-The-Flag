﻿namespace CTF.Application.Maps.Services;

/// <summary>
/// Represents a service to load information from a map.
/// </summary>
public class MapInfoService
{
    private CurrentMap _currentMap;
    public MapInfoService()
    {
        int defaultMapId = 0;
        IMap defaultMap = MapCollection.GetById(defaultMapId).Value;
        Load(defaultMap);
    }

    /// <summary>
    /// Reads the current information from a map.
    /// </summary>
    public CurrentMap Read() => _currentMap;

    /// <summary>
    /// Loads map information from the file system.
    /// </summary>
    /// <param name="map">The map to load.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Load(IMap map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var basePath = AppContext.BaseDirectory;
        var path = Path.Combine(basePath, "Maps", "Files", $"{map.Name}.ini");
        ISectionsData sections = SectionsFile.Load(path);
        SpawnLocation[] alphaTeamLocations = GetLocations(sections["Alpha"]);
        SpawnLocation[] betaTeamLocations = GetLocations(sections["Beta"]);
        sections.TryGetData(section: "Interior",  out ISectionData retrievedInterior);
        sections.TryGetData(section: "Weather",   out ISectionData retrievedWeather);
        sections.TryGetData(section: "WorldTime", out ISectionData retrievedWorldTime);

        int interior = retrievedInterior is null ? 
            CurrentMap.DefaultInterior : 
            int.Parse(retrievedInterior.First());

        int weather = retrievedWeather is null ?
            CurrentMap.DefaultWeather : 
            int.Parse(retrievedWeather.First());

        int worldTime = retrievedWorldTime is null ?
            CurrentMap.DefaultWorldTime : 
            int.Parse(retrievedWorldTime.First());

        _currentMap = new CurrentMap(
            map, 
            alphaTeamLocations, 
            betaTeamLocations, 
            interior, 
            weather, 
            worldTime);
    }

    private static SpawnLocation[] GetLocations(ISectionData section)
    {
        var locations = new SpawnLocation[section.Count];
        for(int i = 0; i < section.Count; i++)
        {
            string data = section[i];
            string[] coordinates = data.Split(',');
            var position = new Vector3(
                float.Parse(coordinates[0], CultureInfo.InvariantCulture),
                float.Parse(coordinates[1], CultureInfo.InvariantCulture),
                float.Parse(coordinates[2], CultureInfo.InvariantCulture)
            );
            float angle = float.Parse(coordinates[3], CultureInfo.InvariantCulture);
            var spawnLocation = new SpawnLocation(position, angle);
            locations[i] = spawnLocation;
        }
        return locations;
    }
}
