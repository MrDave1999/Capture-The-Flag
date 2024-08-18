namespace CTF.Application.Tests.Teams;

public class TeamTests
{
    [SetUp]
    public void Init()
    {
        Team.Alpha.Reset();
        Team.Beta.Reset();
    }

    [Test]
    public void GetMembersAsText_WhenMembersAreObtained_ShouldReturnsValidStringFormat()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        alphaTeam.Members.Add(new FakePlayer(id: 1, name: "Bob"));
        var expectedString = "~r~1";

        // Act
        string actual = alphaTeam.GetMembersAsText();

        // Assert
        actual.Should().Be(expectedString);
    }

    [Test]
    public void GetScoreAsText_WhenScoreIsObtained_ShouldReturnsValidStringFormat()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        alphaTeam.StatsPerRound.AddScore();
        var expectedString = "~r~Alpha: 1";

        // Act
        string actual = alphaTeam.GetScoreAsText();

        // Assert
        actual.Should().Be(expectedString);
    }

    [Test]
    public void IsFull_WhenTeamIsFull_ShouldReturnsTrue()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        alphaTeam.Members.Add(new FakePlayer(id: 1, name: "Bob"));
        alphaTeam.Members.Add(new FakePlayer(id: 2, name: "Alice"));
        betaTeam.Members.Add(new FakePlayer(id: 3, name: "Dave"));

        // Act
        bool actual = alphaTeam.IsFull();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsFull_WhenTeamIsNotFull_ShouldReturnsFalse()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        alphaTeam.Members.Add(new FakePlayer(id: 1, name: "Bob"));
        betaTeam.Members.Add(new FakePlayer(id: 3, name: "Dave"));

        // Act
        bool actual = alphaTeam.IsFull();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void IsWinner_WhenTeamIsWinner_ShouldReturnsTrue()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        alphaTeam.StatsPerRound.AddScore();
        alphaTeam.StatsPerRound.AddScore();
        betaTeam.StatsPerRound.AddScore();

        // Act
        bool actual = alphaTeam.IsWinner();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsWinner_WhenTeamIsNotWinner_ShouldReturnsFalse()
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        alphaTeam.StatsPerRound.AddScore();
        betaTeam.StatsPerRound.AddScore();
        betaTeam.StatsPerRound.AddScore();

        // Act
        bool actual = alphaTeam.IsWinner();

        // Assert
        actual.Should().BeFalse();
    }

    [TestCase("~y~Alpha~n~~r~ not available", true)]
    [TestCase("not available", false)]
    public void GetAvailabilityMessage_WhenTeamIsFull_ShouldReturnsUnavailableMessage(
        string expectedMessage, bool entireMessage)
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        alphaTeam.Members.Add(new FakePlayer(id: 1, name: "Bob"));
        alphaTeam.Members.Add(new FakePlayer(id: 2, name: "Alice"));
        betaTeam.Members.Add(new FakePlayer(id: 3, name: "Dave"));

        // Act
        string actual = alphaTeam.GetAvailabilityMessage(entireMessage);

        // Assert
        actual.Should().Be(expectedMessage);
    }

    [TestCase("~y~Alpha~n~~r~ available", true)]
    [TestCase("available", false)]
    public void GetAvailabilityMessage_WhenTeamIsNotFull_ShouldReturnsAvailableMessage(
        string expectedMessage, bool entireMessage)
    {
        // Arrange
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        alphaTeam.Members.Add(new FakePlayer(id: 1, name: "Bob"));
        betaTeam.Members.Add(new FakePlayer(id: 3, name: "Dave"));

        // Act
        string actual = alphaTeam.GetAvailabilityMessage(entireMessage);

        // Assert
        actual.Should().Be(expectedMessage);
    }
}
