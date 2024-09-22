namespace CTF.Application.Tests.Teams;

public class GetFlagStatusTests
{
    [SetUp]
    public void Init()
    {
        Team.Alpha.Reset();
        Team.Beta.Reset();
    }

    [Test]
    public void GetFlagStatus_WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Player flagPicker = default;

        // Act
        Action act = () => alphaTeam.GetFlagStatus(flagPicker);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void GetFlagStatus_WhenAlphaTeamCapturesTheFlagOfTheBetaTeam_ShouldReturnsCapturedStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        var alphaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: alphaTeam.Id);
        var expectedStatus = FlagStatus.Captured;

        // Act
        FlagStatus actual = betaTeam.GetFlagStatus(flagPicker: alphaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        betaTeam.IsFlagAtBasePosition.Should().BeFalse();
        betaTeam.Flag.Carrier.Should().Be(alphaTeamPlayer);
    }

    [Test]
    public void GetFlagStatus_WhenBetaTeamCapturesTheFlagOfTheAlphaTeam_ShouldReturnsCapturedStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        var betaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: betaTeam.Id);
        var expectedStatus = FlagStatus.Captured;

        // Act
        FlagStatus actual = alphaTeam.GetFlagStatus(flagPicker: betaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        alphaTeam.IsFlagAtBasePosition.Should().BeFalse();
        alphaTeam.Flag.Carrier.Should().Be(betaTeamPlayer);
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromAlphaTeamBroughtTheFlagOfTheBetaTeamToTheirOwnBase_ShouldReturnsBroughtStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        var alphaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: alphaTeam.Id);
        var expectedStatus = FlagStatus.Brought;
        int expectedScore = 1;
        betaTeam.Flag.SetCarrier(alphaTeamPlayer);

        // Act
        FlagStatus actual = alphaTeam.GetFlagStatus(flagPicker: alphaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        betaTeam.Flag.Carrier.Should().BeNull();
        betaTeam.IsFlagAtBasePosition.Should().BeTrue();
        alphaTeam.StatsPerRound.Score.Should().Be(expectedScore);
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromBetaTeamBroughtTheFlagOfTheAlphaTeamToTheirOwnBase_ShouldReturnsBroughtStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        var betaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: betaTeam.Id);
        var expectedStatus = FlagStatus.Brought;
        int expectedScore = 1;
        alphaTeam.Flag.SetCarrier(betaTeamPlayer);

        // Act
        FlagStatus actual = betaTeam.GetFlagStatus(flagPicker: betaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        alphaTeam.Flag.Carrier.Should().BeNull();
        alphaTeam.IsFlagAtBasePosition.Should().BeTrue();
        betaTeam.StatsPerRound.Score.Should().Be(expectedScore);
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromAlphaTeamAttemptsToCaptureTheFlagOfTheirTeamFromBase_ShouldReturnsInitialPositionStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        var alphaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: alphaTeam.Id);
        var expectedStatus = FlagStatus.InitialPosition;

        // Act
        FlagStatus actual = alphaTeam.GetFlagStatus(flagPicker: alphaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        alphaTeam.Flag.Carrier.Should().BeNull();
        alphaTeam.IsFlagAtBasePosition.Should().BeTrue();
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromBetaTeamAttemptsToCaptureTheFlagOfTheirTeamFromBase_ShouldReturnsInitialPositionStatus()
    {
        // Arrange
        Team betaTeam = Team.Beta;
        var betaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: betaTeam.Id);
        var expectedStatus = FlagStatus.InitialPosition;

        // Act
        FlagStatus actual = betaTeam.GetFlagStatus(flagPicker: betaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        betaTeam.Flag.Carrier.Should().BeNull();
        betaTeam.IsFlagAtBasePosition.Should().BeTrue();
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromAlphaTeamReturnsTheFlagOfTheirOwnTeam_ShouldReturnsReturnedStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        var alphaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: alphaTeam.Id);
        var expectedStatus = FlagStatus.Returned;
        alphaTeam.IsFlagAtBasePosition = false;

        // Act
        FlagStatus actual = alphaTeam.GetFlagStatus(flagPicker: alphaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        alphaTeam.IsFlagAtBasePosition.Should().BeTrue();
        alphaTeam.Flag.Carrier.Should().BeNull();
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromBetaTeamReturnsTheFlagOfTheirOwnTeam_ShouldReturnsReturnedStatus()
    {
        // Arrange
        Team betaTeam = Team.Beta;
        var betaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: betaTeam.Id);
        var expectedStatus = FlagStatus.Returned;
        betaTeam.IsFlagAtBasePosition = false;

        // Act
        FlagStatus actual = betaTeam.GetFlagStatus(flagPicker: betaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        betaTeam.IsFlagAtBasePosition.Should().BeTrue();
        betaTeam.Flag.Carrier.Should().BeNull();
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromBetaTeamTakesTheFlagOfTheAlphaTeamFrom_A_PositionOtherThanTheBase_ShouldReturnsTakenStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        var betaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: betaTeam.Id);
        var expectedStatus = FlagStatus.Taken;
        alphaTeam.IsFlagAtBasePosition = false;

        // Act
        FlagStatus actual = alphaTeam.GetFlagStatus(flagPicker: betaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        alphaTeam.IsFlagAtBasePosition.Should().BeFalse();
        alphaTeam.Flag.Carrier.Should().Be(betaTeamPlayer);
    }

    [Test]
    public void GetFlagStatus_WhenPlayerFromAlphaTeamTakesTheFlagOfTheBetaTeamFrom_A_PositionOtherThanTheBase_ShouldReturnsTakenStatus()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        var alphaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: alphaTeam.Id);
        var expectedStatus = FlagStatus.Taken;
        betaTeam.IsFlagAtBasePosition = false;

        // Act
        FlagStatus actual = betaTeam.GetFlagStatus(flagPicker: alphaTeamPlayer);

        // Asserts
        actual.Should().Be(expectedStatus);
        betaTeam.IsFlagAtBasePosition.Should().BeFalse();
        betaTeam.Flag.Carrier.Should().Be(alphaTeamPlayer);
    }
}
