namespace Persistence.Tests;

public class IPlayerRepositoryTests
{
    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void GetOrDefault_WhenPlayerExists_ShouldReturnPlayerInfo(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "moderator_player";

        // Act
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Asserts
        actual.AccountId.Should().Be(2);
        actual.Name.Should().Be("Moderator_Player");
        actual.RoleId.Should().Be(RoleId.Moderator);
        actual.RankId.Should().Be(RankId.Noob);
        actual.SkinId.Should().Be(146);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void GetOrDefault_WhenPlayerDoesNotExist_ShouldReturnNull(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "NotFound";

        // Act
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.Should().BeNull();
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void Exists_WhenPlayerExists_ShouldReturnTrue(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "moderator_player";

        // Act
        bool actual = playerRepository.Exists(playerName);

        // Assert
        actual.Should().BeTrue();
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void Exists_WhenPlayerDoesNotExist_ShouldReturnFalse(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "NotFound";

        // Act
        bool actual = playerRepository.Exists(playerName);

        // Assert
        actual.Should().BeFalse();
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void Create_WhenCalled_ShouldCreatePlayerAndSetAccountId(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerInfo = new PlayerInfo();
        playerInfo.SetName("Player1");
        playerInfo.SetPassword("DSR8887$#");

        // Act
        playerRepository.Create(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerInfo.Name);

        // Asserts
        actual.AccountId.Should().BeGreaterThan(0);
        actual.Name.Should().Be(playerInfo.Name);
        actual.Password.Should().Be(playerInfo.Password);
        actual.RoleId.Should().Be(RoleId.Basic);
        actual.RankId.Should().Be(RankId.Noob);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdatePlayerName(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var oldName = "Moderator_Player";
        var newName = "Player1";
        PlayerInfo playerInfo = playerRepository.GetOrDefault(oldName);
        playerInfo.SetName(newName);

        // Act
        playerRepository.UpdateName(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(newName);

        // Assert
        actual.Name.Should().Be(newName);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdatePlayerPassword(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        var expectedPassword = "D123456$";
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetPassword(expectedPassword);

        // Act
        playerRepository.UpdatePassword(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.Password.Should().Be(expectedPassword);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateTotalKills(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedTotalKills = 20;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetTotalKills(expectedTotalKills);

        // Act
        playerRepository.UpdateTotalKills(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.TotalKills.Should().Be(expectedTotalKills);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateTotalDeaths(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedTotalDeaths = 100;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetTotalDeaths(expectedTotalDeaths);

        // Act
        playerRepository.UpdateTotalDeaths(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.TotalDeaths.Should().Be(expectedTotalDeaths);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateMaxKillingSpree(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedKillingSpree = 25;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetMaxKillingSpree(expectedKillingSpree);

        // Act
        playerRepository.UpdateMaxKillingSpree(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.MaxKillingSpree.Should().Be(expectedKillingSpree);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateBroughtFlags(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedBroughtFlags = 2;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.AddBroughtFlags();
        playerInfo.AddBroughtFlags();

        // Act
        playerRepository.UpdateBroughtFlags(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.BroughtFlags.Should().Be(expectedBroughtFlags);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateCapturedFlags(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedCapturedFlags = 2;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.AddCapturedFlags();
        playerInfo.AddCapturedFlags();

        // Act
        playerRepository.UpdateCapturedFlags(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.CapturedFlags.Should().Be(expectedCapturedFlags);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateDroppedFlags(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedDroppedFlags = 2;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.AddDroppedFlags();
        playerInfo.AddDroppedFlags();

        // Act
        playerRepository.UpdateDroppedFlags(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.DroppedFlags.Should().Be(expectedDroppedFlags);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateReturnedFlags(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedReturnedFlags = 2;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.AddReturnedFlags();
        playerInfo.AddReturnedFlags();

        // Act
        playerRepository.UpdateReturnedFlags(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.ReturnedFlags.Should().Be(expectedReturnedFlags);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateHeadShots(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedHeadShots = 2;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.AddHeadShots();
        playerInfo.AddHeadShots();

        // Act
        playerRepository.UpdateHeadShots(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.HeadShots.Should().Be(expectedHeadShots);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateRole(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        RoleId expectedRoleId = RoleId.Admin;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetRole(expectedRoleId);

        // Act
        playerRepository.UpdateRole(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.RoleId.Should().Be(expectedRoleId);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateSkin(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        int expectedSkinId = 100;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetSkin(expectedSkinId);

        // Act
        playerRepository.UpdateSkin(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.SkinId.Should().Be(expectedSkinId);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateRank(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        RankId expectedRankId = RankId.GameMaster;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetRank(expectedRankId);

        // Act
        playerRepository.UpdateRank(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.RankId.Should().Be(expectedRankId);
    }

    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void ShouldUpdateLastConnection(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        var playerRepository = repositoryManager.PlayerRepository;
        var playerName = "Moderator_Player";
        PlayerInfo playerInfo = playerRepository.GetOrDefault(playerName);
        playerInfo.SetLastConnection();

        // Act
        playerRepository.UpdateLastConnection(playerInfo);
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.LastConnection.Should().Be(playerInfo.LastConnection);
    }
}
