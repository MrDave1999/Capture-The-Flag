namespace CTF.Application.Maps;

/// <summary>
/// Represents the current information of a map.
/// </summary>
public class CurrentMap
{
    private IMap _nextMap;
    private readonly Random _random = new();
    public const int DefaultInterior  = 0;
    public const int DefaultWeather   = 10;
    public const int DefaultWorldTime = 12;
    public int Id { get; }
    public string Name { get; }
    public IReadOnlyList<SpawnLocation> AlphaTeamLocations { get; }
    public IReadOnlyList<SpawnLocation> BetaTeamLocations { get; }
    public int Interior { get; }
    public int Weather { get; }
    public int WorldTime { get; }
    public IMap NextMap => _nextMap;
    public int IsLoading { get; set; }

    public CurrentMap(
        IMap map, 
        IReadOnlyList<SpawnLocation> alphaTeamLocations, 
        IReadOnlyList<SpawnLocation> betaTeamLocations,
        int interior  = DefaultInterior,
        int weather   = DefaultWeather,
        int worldTime = DefaultWorldTime)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(alphaTeamLocations);
        ArgumentNullException.ThrowIfNull(betaTeamLocations);

        if (alphaTeamLocations.Count == 0)
            throw new ArgumentException(Messages.LocationListCannotBeEmpty, nameof(alphaTeamLocations));

        if (betaTeamLocations.Count == 0)
            throw new ArgumentException(Messages.LocationListCannotBeEmpty, nameof(betaTeamLocations));

        Id = map.Id;
        Name = map.Name;
        AlphaTeamLocations = alphaTeamLocations;
        BetaTeamLocations = betaTeamLocations;
        Interior = interior;
        Weather = weather;
        WorldTime = worldTime;
        int nextMapId = (Id + 1) % MapCollection.Count;
        _nextMap = MapCollection.GetById(nextMapId).Value;
    }

    public string GetMapNameAsText() => $"Map: ~w~{Name}";
    public void SetNextMap(IMap nextMap)
    {
        ArgumentNullException.ThrowIfNull(nextMap);
        _nextMap = nextMap;
    }

    public SpawnLocation GetRandomSpawnLocation(TeamId team) => team switch
    {
        TeamId.Alpha => AlphaTeamLocations[_random.Next(AlphaTeamLocations.Count)],
        TeamId.Beta => BetaTeamLocations[_random.Next(BetaTeamLocations.Count)],
        _ => throw new NotSupportedException(Messages.SpawnLocationFailure)
    };
}
