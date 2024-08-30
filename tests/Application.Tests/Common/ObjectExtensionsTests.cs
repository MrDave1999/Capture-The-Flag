namespace CTF.Application.Tests.Common;

public class ObjectExtensionsTests
{
    [Test]
    public void SetValue_WhenObjectIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        PlayerInfo @object = default;
        string value = "Admin_Player";
        string propertyName = nameof(PlayerInfo.Name);

        // Act
        Action act = () => ObjectExtensions.SetValue(@object, value, propertyName);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void SetValue_WhenValueIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var player = new PlayerInfo();
        string value = default;
        string propertyName = nameof(PlayerInfo.Name);

        // Act
        Action act = () => player.SetValue(value, propertyName);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void SetValue_WhenPropertyNameIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var player = new PlayerInfo();
        string value = "Admin_Player";
        string propertyName = default;

        // Act
        Action act = () => player.SetValue(value, propertyName);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void SetValue_WhenPropertyNameIsNotFoundInTheObject_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var player = new PlayerInfo();
        string value = "Admin_Player";
        string propertyName = "PlayerName";

        // Act
        Action act = () => player.SetValue(value, propertyName);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void SetValue_WhenPropertyNameIsFoundInTheObject_ShouldNotThrowInvalidOperationException()
    {
        // Arrange
        var player = new PlayerInfo();
        string value = "Admin_Player";
        string propertyName = nameof(PlayerInfo.Name);
        player.SetName("Bob");

        // Act
        Action act = () => player.SetValue(value, propertyName);

        // Asserts
        act.Should().NotThrow<InvalidOperationException>();
        player.Name.Should().Be(value);
    }
}
