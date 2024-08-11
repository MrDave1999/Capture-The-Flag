namespace CTF.Application.Tests.Players.Accounts;

public class PlayerStatsPerRoundTests
{
    [TestCase(10)]
    [TestCase(9)]
    [TestCase(8)]
    public void HasSufficientPoints_WhenPlayerHasSufficientPoints_ShouldReturnsTrue(int amount)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        stats.AddPoints(10);

        // Act
        bool actual = stats.HasSufficientPoints(amount);

        // Assert
        actual.Should().BeTrue();
    }

    [TestCase(11)]
    [TestCase(12)]
    public void HasSufficientPoints_WhenPlayerHasInsufficientPoints_ShouldReturnsFalse(int amount)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        stats.AddPoints(10);

        // Act
        bool actual = stats.HasSufficientPoints(amount);

        // Assert
        actual.Should().BeFalse();
    }

    [TestCase(10)]
    [TestCase(9)]
    [TestCase(8)]
    public void HasInsufficientPoints_WhenPlayerHasSufficientPoints_ShouldReturnsFalse(int amount)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        stats.AddPoints(10);

        // Act
        bool actual = stats.HasInsufficientPoints(amount);

        // Assert
        actual.Should().BeFalse();
    }

    [TestCase(11)]
    [TestCase(12)]
    public void HasInsufficientPoints_WhenPlayerHasInsufficientPoints_ShouldReturnsTrue(int amount)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        stats.AddPoints(10);

        // Act
        bool actual = stats.HasInsufficientPoints(amount);

        // Assert
        actual.Should().BeTrue();
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(101)]
    public void AddPoints_WhenPointsAreNotBetween1To100_ShouldReturnsFailureResult(int value)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        var expectedMessage = Messages.AddPoints;

        // Act
        Result result = stats.AddPoints(value);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(99)]
    [TestCase(100)]
    public void AddPoints_WhenPointsAreBetween1To100_ShouldReturnsSuccessResult(int value)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();

        // Act
        Result result = stats.AddPoints(value);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        stats.Points.Should().Be(value);
    }

    [TestCase(21)]
    [TestCase(22)]
    [TestCase(23)]
    [TestCase(100)]
    public void AddPoints_WhenSumOfPointsExceedsValueOf100_ShouldSetValueTo100(int value)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        int expectedPoints = 100;
        stats.AddPoints(80);

        // Act
        Result result = stats.AddPoints(value);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        stats.Points.Should().Be(expectedPoints);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(-101)]
    public void SubtractPoints_WhenPointsAreNotInSpecifiedRange_ShouldReturnsFailureResult(int value)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        // Should be in the range of -1 to -100.
        var expectedMessage = Messages.SubtractPoints;

        // Act
        Result result = stats.SubtractPoints(value);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [TestCase(-1)]
    [TestCase(-2)]
    [TestCase(-99)]
    [TestCase(-100)]
    public void SubtractPoints_WhenPointsAreInSpecifiedRange_ShouldReturnsSuccessResult(int value)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        int expectedPoints = 0;

        // Act
        Result result = stats.SubtractPoints(value);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        stats.Points.Should().Be(expectedPoints);
    }

    [TestCase(-11)]
    [TestCase(-12)]
    [TestCase(-13)]
    [TestCase(-100)]
    public void SubtractPoints_WhenSubtractionOfPointsGivesNegativeResult_ShouldSetValueToZero(int value)
    {
        // Arrange
        var stats = new PlayerStatsPerRound();
        int expectedPoints = 0;
        stats.AddPoints(10);

        // Act
        Result result = stats.SubtractPoints(value);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        stats.Points.Should().Be(expectedPoints);
    }
}
