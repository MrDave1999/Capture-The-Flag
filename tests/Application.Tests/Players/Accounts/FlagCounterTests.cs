namespace CTF.Application.Tests.Players.Accounts;

public class FlagCounterTests
{
    [Test]
    public void AddBroughtFlags_WhenCalledTwice_ShouldBeIncreasedTo2()
    {
        // Arrange
        var player = new PlayerInfo();
        int expected = 2;

        // Act
        player.AddBroughtFlags();
        player.AddBroughtFlags();

        // Assert
        player.BroughtFlags.Should().Be(expected);
    }

    [Test]
    public void AddCapturedFlags_WhenCalledTwice_ShouldBeIncreasedTo2()
    {
        // Arrange
        var player = new PlayerInfo();
        int expected = 2;

        // Act
        player.AddCapturedFlags();
        player.AddCapturedFlags();

        // Assert
        player.CapturedFlags.Should().Be(expected);
    }

    [Test]
    public void AddDroppedFlags_WhenCalledTwice_ShouldBeIncreasedTo2()
    {
        // Arrange
        var player = new PlayerInfo();
        int expected = 2;

        // Act
        player.AddDroppedFlags();
        player.AddDroppedFlags();

        // Assert
        player.DroppedFlags.Should().Be(expected);
    }

    [Test]
    public void AddReturnedFlags_WhenCalledTwice_ShouldBeIncreasedTo2()
    {
        // Arrange
        var player = new PlayerInfo();
        int expected = 2;

        // Act
        player.AddReturnedFlags();
        player.AddReturnedFlags();

        // Assert
        player.ReturnedFlags.Should().Be(expected);
    }
}
