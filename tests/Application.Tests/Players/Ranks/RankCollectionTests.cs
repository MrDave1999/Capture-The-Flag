namespace CTF.Application.Tests.Players.Ranks;

public class RankCollectionTests
{
    [TestCase(-1)]
    [TestCase(1000)]
    public void GetById_WhenRankIsInvalid_ShouldReturnsFailureResult(int value)
    {
        // Arrange
        RankId rankId = (RankId)value;
        string expectedMessage = Messages.InvalidRank;

        // Act
        Result<IRank> result = RankCollection.GetById(rankId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetById_WhenRankIsMax_ShouldReturnsFailureResult()
    {
        // Arrange
        int max = RankCollection.Max;
        RankId rankId = (RankId)max;
        string expectedMessage = Messages.InvalidRank;

        // Act
        Result<IRank> result = RankCollection.GetById(rankId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetById_WhenRankIsValid_ShouldReturnsSuccessResult()
    {
        // Arrange
        RankId rankId = RankId.Noob;
        string expectedRank = rankId.ToString();

        // Act
        Result<IRank> result = RankCollection.GetById(rankId);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be(expectedRank);
        result.Message.Should().BeEmpty();
    }

    [TestCase(-1)]
    [TestCase(1000)]
    public void GetNextRank_WhenRankIsInvalid_ShouldReturnsFailureResult(int value)
    {
        // Arrange
        RankId rankId = (RankId)value;
        string expectedMessage = Messages.InvalidRank;

        // Act
        Result<IRank> result = RankCollection.GetNextRank(rankId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetNextRank_WhenRankIsMax_ShouldReturnsFailureResult()
    {
        // Arrange
        int max = RankCollection.Max;
        RankId rankId = (RankId)max;
        string expectedMessage = Messages.InvalidRank;

        // Act
        Result<IRank> result = RankCollection.GetNextRank(rankId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetNextRank_WhenRankIsValid_ShouldReturnsSuccessResult()
    {
        // Arrange
        RankId previousRank = RankId.Noob;
        string expectedNextRank = RankId.Medium.ToString();

        // Act
        Result<IRank> result = RankCollection.GetNextRank(previousRank);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be(expectedNextRank);
    }

    [Test]
    public void GetNextRank_WhenThereIsNoNextRank_ShouldNotReturnsAnyRank()
    {
        // Arrange
        RankId previousRank = RankId.Legendary;
        string expectedNextRank = "None";

        // Act
        Result<IRank> result = RankCollection.GetNextRank(previousRank);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be(expectedNextRank);
    }
}
