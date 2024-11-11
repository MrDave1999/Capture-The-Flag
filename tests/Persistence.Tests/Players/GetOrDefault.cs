namespace Persistence.Tests.Players;

public class GetPlayerOrDefault
{
    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void GetOrDefault_WhenPlayerExists_ShouldReturnPlayerInfo(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        repositoryManager.InitializeSeedData();
        IPlayerRepository playerRepository = repositoryManager.PlayerRepository;
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
        repositoryManager.InitializeSeedData();
        IPlayerRepository playerRepository = repositoryManager.PlayerRepository;
        var playerName = "NotFound";

        // Act
        PlayerInfo actual = playerRepository.GetOrDefault(playerName);

        // Assert
        actual.Should().BeNull();
    }
}
