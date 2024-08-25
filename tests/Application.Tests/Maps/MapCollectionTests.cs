namespace CTF.Application.Tests.Maps;

public class MapCollectionTests
{
    static readonly int[] InvalidMapCases = [-1, 1000, MapCollection.Count];

    [TestCase("de")]
    [TestCase("DE")]
    [TestCase("dE")]
    [TestCase("De")]
    public void GetAll_WhenAllMapsAreObtainedWithFindBy_ShouldReturnsEnumerable(string findBy)
    {
        // Arrange
        string[] expectedMaps =
        [
            "de_aztec",
            "de_dust2",
            "de_dust2_small",
            "de_dust2_x1",
            "de_dust2_x2",
            "de_dust2_x3",
            "de_dust5",
            "DesertGlory"
        ];

        // Act
        IEnumerable<IMap> maps = MapCollection.GetAll(findBy);
        string[] actual = maps.Select(map => map.Name).ToArray();

        // Assert
        actual.Should().BeEquivalentTo(expectedMaps);
    }

    [TestCaseSource(nameof(InvalidMapCases))]
    public void GetById_WhenMapIdIsInvalid_ShouldReturnsFailureResult(int mapId)
    {
        // Arrange
        string expectedMessage = Messages.InvalidMap;

        // Act
        Result<IMap> result = MapCollection.GetById(mapId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void GetById_WhenMapIdIsValid_ShouldReturnsSuccessResult(int mapId)
    {
        // Arrange

        // Act
        Result<IMap> result = MapCollection.GetById(mapId);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Id.Should().Be(mapId);
        result.Value.Name.Should().NotBeNullOrEmpty();
    }

    [Test]
    public void GetByName_WhenMapNameIsNotFound_ShouldReturnsFailureResult()
    {
        // Arrange
        string mapName = "NotFound"; 
        string expectedMessage = Messages.MapNotFound;

        // Act
        Result<IMap> result = MapCollection.GetByName(mapName);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [TestCase("de_aztec")]
    [TestCase("DE_AZTEC")]
    [TestCase("De_Aztec")]
    public void GetByName_WhenMapNameIsFound_ShouldReturnsSuccessResult(string mapName)
    {
        // Arrange
        string expectedMapName = "de_aztec";

        // Act
        Result<IMap> result = MapCollection.GetByName(mapName);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be(expectedMapName);
    }
}
