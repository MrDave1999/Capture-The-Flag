namespace CTF.Application.Tests.Players.Accounts;

public class PlayerInfoTests
{
    static readonly int[] InvalidRankCases = [-1, -2, RankCollection.Max];
    static readonly int[] InvalidSkinCases = [-1, -2, 312];

    [TestCaseSource(nameof(InvalidRankCases))]
    public void SetRank_WhenRankIdIsInvalid_ShouldReturnsFailureResult(int value)
    {
        // Arrange
        var player = new PlayerInfo();
        RankId rankId = (RankId)value;
        var expectedMessage = Messages.InvalidRank;

        // Act
        Result result = player.SetRank(rankId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
        player.RankId.Should().NotBe(rankId);
    }

    [Test]
    public void SetRank_WhenRankIdIsValid_ShouldReturnsSuccessResult()
    {
        // Arrange
        var player = new PlayerInfo();
        RankId rankId = RankId.Maniac;

        // Act
        Result result = player.SetRank(rankId);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        player.RankId.Should().Be(rankId);
    }

    [TestCaseSource(nameof(InvalidSkinCases))]
    public void SetSkin_WhenSkinIdIsInvalid_ShouldReturnsFailureResult(int skinId)
    {
        // Arrange
        var player = new PlayerInfo();
        var expectedMessage = Messages.InvalidSkin;

        // Act
        Result result = player.SetSkin(skinId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void SetSkin_WhenSkinIdIsValid_ShouldReturnsSuccessResult()
    {
        // Arrange
        var player = new PlayerInfo();
        // See https://www.open.mp/docs/scripting/resources/skins
        // Skin valid between 0 to 311.
        int skinId = 311;

        // Act
        Result result = player.SetSkin(skinId);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        player.SkinId.Should().Be(skinId);
    }

    [Test] 
    public void HasSkin_WhenPlayerHasAssignedSkin_ShouldReturnsTrue()
    {
        // Arrange
        var player = new PlayerInfo();
        player.SetSkin(311);

        // Act
        bool actual = player.HasSkin();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void HasSkin_WhenPlayerHasNoAssignedSkin_ShouldReturnsFalse()
    {
        // Arrange
        var player = new PlayerInfo();
        player.RemoveSkin();

        // Act
        bool actual = player.HasSkin();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void SetTotalKills_WhenKillsIsNegative_ShouldReturnsFailureResult()
    {
        // Arrange
        var player = new PlayerInfo();
        int kills = -1;
        var expectedMessage = Messages.ValueCannotBeNegative;

        // Act
        Result result = player.SetTotalKills(kills);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
        player.TotalKills.Should().NotBe(kills);
    }

    [Test]
    public void SetTotalKills_WhenKillsIsPositive_ShouldReturnsSuccessResult()
    {
        // Arrange
        var player = new PlayerInfo();
        int kills = 10;

        // Act
        Result result = player.SetTotalKills(kills);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        player.TotalKills.Should().Be(kills);
    }

    [Test]
    public void SetTotalDeaths_WhenDeathsIsNegative_ShouldReturnsFailureResult()
    {
        // Arrange
        var player = new PlayerInfo();
        int deaths = -1;
        var expectedMessage = Messages.ValueCannotBeNegative;

        // Act
        Result result = player.SetTotalDeaths(deaths);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
        player.TotalDeaths.Should().NotBe(deaths);
    }

    [Test]
    public void SetTotalDeaths_WhenDeathsIsPositive_ShouldReturnsSuccessResult()
    {
        // Arrange
        var player = new PlayerInfo();
        int deaths = 10;

        // Act
        Result result = player.SetTotalDeaths(deaths);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        player.TotalDeaths.Should().Be(deaths);
    }

    [Test]
    public void HasSurpassedMaxKillingSpree_WhenNewRecordIsAchieved_ShouldReturnsTrue()
    {
        // Arrange
        var player = new PlayerInfo();
        player.StatsPerRound.AddKillingSpree();
        player.StatsPerRound.AddKillingSpree();
        player.StatsPerRound.AddKillingSpree();
        player.SetMaxKillingSpree(2);

        // Act
        bool actual = player.HasSurpassedMaxKillingSpree();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void HasSurpassedMaxKillingSpree_WhenNewRecordIsNotAchieved_ShouldReturnsFalse()
    {
        // Arrange
        var player = new PlayerInfo();
        player.StatsPerRound.AddKillingSpree();
        player.StatsPerRound.AddKillingSpree();
        player.SetMaxKillingSpree(3);

        // Act
        bool actual = player.HasSurpassedMaxKillingSpree();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void HasRank_WhenRankIsNoob_ShouldReturnsTrue()
    {
        // Arrange
        var player = new PlayerInfo();
        RankId rankId = RankId.Noob;
        player.SetRank(rankId);

        // Act
        bool actual = player.HasRank(rankId);

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void HasRank_WhenRankIsNotNoob_ShouldReturnsFalse()
    {
        // Arrange
        var player = new PlayerInfo();
        player.SetRank(RankId.Noob);

        // Act
        bool actual = player.HasRank(RankId.Junior);

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void CanMoveUpToNextRank_WhenPlayerHasMaximumRank_ShouldReturnsFalse()
    {
        // Arrange
        var player = new PlayerInfo();
        RankId maxRank = RankId.Legendary;
        player.SetRank(maxRank);
        player.SetTotalKills(701);

        // Act
        bool actual = player.CanMoveUpToNextRank();

        // Assert
        actual.Should().BeFalse();
    }

    [TestCase(50)]
    [TestCase(51)]
    public void CanMoveUpToNextRank_WhenPlayerDoesHaveRequiredKills_ShouldReturnsTrue(int requiredKills)
    {
        // Arrange
        var player = new PlayerInfo();
        player.SetRank(RankId.Noob);
        player.SetTotalKills(requiredKills);

        // Act
        bool actual = player.CanMoveUpToNextRank();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void CanMoveUpToNextRank_WhenPlayerDoesNotHaveRequiredKills_ShouldReturnsFalse()
    {
        // Arrange
        var player = new PlayerInfo();
        player.SetRank(RankId.Noob);
        player.SetTotalKills(10);

        // Act
        bool actual = player.CanMoveUpToNextRank();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void GetStatsAsText_WhenStatsAreObtained_ShouldReturnsValidStringFormat()
    {
        // Arrange
        var player = new PlayerInfo();
        int maxRank = RankCollection.Max;
        var expectedString =
            "~w~KILLS: ~y~0 ~w~DEATHS: ~y~0 ~w~SPREE: ~y~0 " +
            $"~w~POINTS: ~y~0/100 ~w~LEVEL: ~y~0/{maxRank} ~w~RANK: ~y~Noob";

        // Act
        string actual = player.GetStatsAsText();

        // Assert
        actual.Should().Be(expectedString);
    }
}
