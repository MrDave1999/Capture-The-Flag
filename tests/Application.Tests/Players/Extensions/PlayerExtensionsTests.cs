namespace CTF.Application.Tests.Players.Extensions;

public class PlayerExtensionsTests
{
    [Test]
    public void GetInfo_WhenNoAccountComponent_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var fakePlayer = new FakePlayer1();

        // Act
        Action act = () => fakePlayer.GetInfo();

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void GetInfo_WhenAccountComponentIsAssigned_ShouldNotThrowInvalidOperationException()
    {
        // Arrange
        var fakePlayer = new FakePlayer2();

        // Act
        Action act = () => fakePlayer.GetInfo();

        // Assert
        act.Should().NotThrow<InvalidOperationException>();
    }

    private class FakePlayer1 : Player
    {
        public override T GetComponent<T>()
        {
            return null;
        }
    }

    private class FakePlayer2 : Player
    {
        public override T GetComponent<T>()
        {
            var accountComponent = new AccountComponent(new PlayerInfo());
            return accountComponent as T;
        }
    }
}
