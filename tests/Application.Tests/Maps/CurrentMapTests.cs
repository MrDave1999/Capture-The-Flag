﻿namespace CTF.Application.Tests.Maps;

public class CurrentMapTests
{
    [Test]
    public void Constructor_WhenMapIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        IMap map = default;
        List<SpawnLocation> locations = [SpawnLocation.Empty];

        // Act
        Action act = () =>
        {
            var currentMap = new CurrentMap(map, locations, locations);
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(map));
    }

    [Test]
    public void Constructor_WhenAlphaTeamLocationsIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        IMap map = MapCollection.GetById(0).Value;
        List<SpawnLocation> alphaTeamLocations = default;
        List<SpawnLocation> betaTeamLocations = [SpawnLocation.Empty];

        // Act
        Action act = () =>
        {
            var currentMap = new CurrentMap(map, alphaTeamLocations, betaTeamLocations);
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(alphaTeamLocations));
    }

    [Test]
    public void Constructor_WhenBetaTeamLocationsIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        IMap map = MapCollection.GetById(0).Value;
        List<SpawnLocation> betaTeamLocations = default;
        List<SpawnLocation> alphaTeamLocations = [SpawnLocation.Empty];

        // Act
        Action act = () =>
        {
            var currentMap = new CurrentMap(map, alphaTeamLocations, betaTeamLocations);
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(betaTeamLocations));
    }

    [Test]
    public void Constructor_WhenAlphaTeamLocationsIsEmpty_ShouldThrowArgumentException()
    {
        // Arrange
        IMap map = MapCollection.GetById(0).Value;
        List<SpawnLocation> alphaTeamLocations = [];
        List<SpawnLocation> betaTeamLocations = [SpawnLocation.Empty];

        // Act
        Action act = () =>
        {
            var currentMap = new CurrentMap(map, alphaTeamLocations, betaTeamLocations);
        };

        // Assert
        act.Should()
           .Throw<ArgumentException>()
           .WithParameterName(nameof(alphaTeamLocations));
    }

    [Test]
    public void Constructor_WhenBetaTeamLocationsIsEmpty_ShouldThrowArgumentException()
    {
        // Arrange
        IMap map = MapCollection.GetById(0).Value;
        List<SpawnLocation> alphaTeamLocations = [SpawnLocation.Empty];
        List<SpawnLocation> betaTeamLocations = [];

        // Act
        Action act = () =>
        {
            var currentMap = new CurrentMap(map, alphaTeamLocations, betaTeamLocations);
        };

        // Assert
        act.Should()
           .Throw<ArgumentException>()
           .WithParameterName(nameof(betaTeamLocations));
    }

    [TestCaseSource(typeof(GetNextMapTestCases))]
    public void NextMap_WhenMapIsObtained_ShouldReturnsNextMap((IMap Map, IMap Expected) data)
    {
        // Arrange
        List<SpawnLocation> locations = [SpawnLocation.Empty];
        var currentMap = new CurrentMap(data.Map, locations, locations);

        // Act
        IMap actual = currentMap.NextMap;

        // Assert
        actual.Should().Be(data.Expected);
    }

    [Test]
    public void GetMapNameAsText_WhenNameIsObtained_ShouldReturnsValidStringFormat()
    {
        // Arrange
        IMap map = MapCollection.GetByName("RC_Battlefield").Value;
        List<SpawnLocation> locations = [SpawnLocation.Empty];
        var currentMap = new CurrentMap(map, locations, locations);
        var expectedString = "Map: ~w~RC_Battlefield";

        // Act
        string actual = currentMap.GetMapNameAsText();

        // Assert
        actual.Should().Be(expectedString);
    }

    [Test]
    public void SetNextMap_WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        IMap map = MapCollection.GetById(0).Value;
        IMap nextMap = default;
        List<SpawnLocation> locations = [SpawnLocation.Empty];
        var currentMap = new CurrentMap(map, locations, locations);

        // Act
        Action act = () => currentMap.SetNextMap(nextMap);

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(nextMap));
    }

    [TestCase(TeamId.Alpha)]
    [TestCase(TeamId.Beta)]
    public void GetRandomSpawnLocation_WhenTeamIsAlphaOrBeta_ShouldReturnsSpawnLocation(TeamId team)
    {
        // Arrange
        IMap map = MapCollection.GetById(0).Value;
        List<SpawnLocation> locations = [SpawnLocation.Empty];
        var currentMap = new CurrentMap(map, locations, locations);
        SpawnLocation expectedSpawnLocation = locations[0];

        // Act
        SpawnLocation actual = currentMap.GetRandomSpawnLocation(team);

        // Assert
        actual.Should().Be(expectedSpawnLocation);
    }

    [Test]
    public void GetRandomSpawnLocation_WhenTeamIsNotAlphaOrBeta_ShouldThrowNotSupportedException()
    {
        // Arrange
        IMap map = MapCollection.GetById(0).Value;
        List<SpawnLocation> locations = [SpawnLocation.Empty];
        TeamId team = TeamId.NoTeam;
        var currentMap = new CurrentMap(map, locations, locations);

        // Act
        Action act = () => currentMap.GetRandomSpawnLocation(team);

        // Assert
        act.Should().Throw<NotSupportedException>();
    }
}