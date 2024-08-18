namespace CTF.Application.Tests.Teams;

public class TeamStatsPerRoundTests
{
    [Test]
    public void AddScore_WhenScoreIsAdded_ShouldUpdateScore()
    {
        // Arrange
        var stats = new TeamStatsPerRound();
        int expectedScore = 2;

        // Act
        stats.AddScore();
        stats.AddScore();

        // Assert
        stats.Score.Should().Be(expectedScore);
    }

    [Test]
    public void AddKills_WhenKillIsAdded_ShouldUpdateKills()
    {
        // Arrange
        var stats = new TeamStatsPerRound();
        int expectedKills = 2;

        // Act
        stats.AddKills();
        stats.AddKills();

        // Assert
        stats.Kills.Should().Be(expectedKills);
    }

    [Test]
    public void AddDeaths_WhenDeathIsAdded_ShouldUpdateDeaths()
    {
        // Arrange
        var stats = new TeamStatsPerRound();
        int expectedDeaths = 2;

        // Act
        stats.AddDeaths();
        stats.AddDeaths();

        // Assert
        stats.Deaths.Should().Be(expectedDeaths);
    }

    [Test]
    public void Reset_WhenStatsAreReset_ShouldUpdateStats()
    {
        // Arrange
        var stats = new TeamStatsPerRound();
        stats.AddScore();
        stats.AddScore();
        stats.AddKills();
        stats.AddKills();
        stats.AddDeaths();
        stats.AddDeaths();

        // Act
        stats.Reset();

        // Asserts
        stats.Score.Should().Be(0);
        stats.Kills.Should().Be(0);
        stats.Deaths.Should().Be(0);
    }
}
