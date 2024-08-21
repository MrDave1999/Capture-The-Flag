namespace CTF.Application.Tests.Players.Accounts;

public class HasCapturedFlagTests
{
    [SetUp]
    public void Init()
    {
        Team.Alpha.Reset();
        Team.Beta.Reset();
    }

    [Test]
    public void HasCapturedFlag_WhenPlayerIsNotAssignedToAnyTeam_ShouldReturnsFalse()
    {
        // Arrange
        var fakePlayer = new FakePlayer(id: 1, name: "Bob", team: TeamId.NoTeam);
        var player = new PlayerInfo(fakePlayer.Entity);
        player.SetTeam(TeamId.NoTeam);
        player.SetName("Bob");

        // Act
        bool actual = player.HasCapturedFlag();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void HasCapturedFlag_WhenPlayerFromTheAlphaTeamHasCapturedTheFlagOfTheBetaTeam_ShouldReturnsTrue()
    {
        // Arrange
        Team betaTeam = Team.Beta;
        var alphaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: TeamId.Alpha);
        var player = new PlayerInfo(alphaTeamPlayer.Entity);
        player.SetTeam(TeamId.Alpha);
        player.SetName("Bob");
        betaTeam.Flag.SetCarrier(alphaTeamPlayer);

        // Act
        bool actual = player.HasCapturedFlag();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void HasCapturedFlag_WhenPlayerFromTheBetaTeamHasCapturedTheFlagOfTheAlphaTeam_ShouldReturnsTrue()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        var betaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: TeamId.Beta);
        var player = new PlayerInfo(betaTeamPlayer.Entity);
        player.SetTeam(TeamId.Beta);
        player.SetName("Bob");
        alphaTeam.Flag.SetCarrier(betaTeamPlayer);

        // Act
        bool actual = player.HasCapturedFlag();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void HasCapturedFlag_WhenPlayerFromTheAlphaTeamHasNotCapturedTheFlagOfTheBetaTeam_ShouldReturnsFalse()
    {
        // Arrange
        Team betaTeam = Team.Beta;
        var alphaTeamPlayer1 = new FakePlayer(id: 1, name: "Bob", team: TeamId.Alpha);
        var alphaTeamPlayer2 = new FakePlayer(id: 2, name: "Alice", team: TeamId.Alpha);
        var player = new PlayerInfo(alphaTeamPlayer1.Entity);
        player.SetTeam(TeamId.Alpha);
        player.SetName("Bob");
        betaTeam.Flag.SetCarrier(alphaTeamPlayer2);

        // Act
        bool actual = player.HasCapturedFlag();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void HasCapturedFlag_WhenPlayerFromTheBetaTeamHasNotCapturedTheFlagOfTheAlphaTeam_ShouldReturnsFalse()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        var betaTeamPlayer1 = new FakePlayer(id: 1, name: "Bob", team: TeamId.Beta);
        var betaTeamPlayer2 = new FakePlayer(id: 2, name: "Alice", team: TeamId.Beta);
        var player = new PlayerInfo(betaTeamPlayer1.Entity);
        player.SetTeam(TeamId.Beta);
        player.SetName("Bob");
        alphaTeam.Flag.SetCarrier(betaTeamPlayer2);

        // Act
        bool actual = player.HasCapturedFlag();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void HasCapturedFlag_WhenAlphaTeamFlagIsNotCaptured_ShouldReturnsFalse()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        var betaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: TeamId.Beta);
        var player = new PlayerInfo(betaTeamPlayer.Entity);
        player.SetTeam(TeamId.Beta);
        player.SetName("Bob");
        alphaTeam.Flag.RemoveCarrier();

        // Act
        bool actual = player.HasCapturedFlag();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void HasCapturedFlag_WhenBetaTeamFlagIsNotCaptured_ShouldReturnsFalse()
    {
        // Arrange
        Team betaTeam = Team.Beta;
        var alphaTeamPlayer = new FakePlayer(id: 1, name: "Bob", team: TeamId.Alpha);
        var player = new PlayerInfo(alphaTeamPlayer.Entity);
        player.SetTeam(TeamId.Alpha);
        player.SetName("Bob");
        betaTeam.Flag.RemoveCarrier();

        // Act
        bool actual = player.HasCapturedFlag();

        // Assert
        actual.Should().BeFalse();
    }
}
