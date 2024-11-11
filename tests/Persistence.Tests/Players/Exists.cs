namespace Persistence.Tests.Players;

public class PlayerExists
{
    [TestCaseSource(typeof(RepositoryManagerTestCases))]
    public void Exists_WhenPlayerExists_ShouldReturnTrue(IRepositoryManager source)
    {
        // Arrange
        using var repositoryManager = source;
        repositoryManager.InitializeSeedData();
        IPlayerRepository playerRepository = repositoryManager.PlayerRepository;
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
        repositoryManager.InitializeSeedData();
        IPlayerRepository playerRepository = repositoryManager.PlayerRepository;
        var playerName = "NotFound";

        // Act
        bool actual = playerRepository.Exists(playerName);

        // Assert
        actual.Should().BeFalse();
    }
}
