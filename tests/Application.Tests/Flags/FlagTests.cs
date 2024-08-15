namespace CTF.Application.Tests.Flags;

public class FlagTests
{
    [Test]
    public void IsCaptured_WhenFlagIsCapturedByPlayer_ShouldReturnsTrue()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Name = "Red",
            ColorHex = Color.Red
        };
        Player player = (Player)Activator.CreateInstance(type: typeof(Player), nonPublic: true);
        flag.GetType()
            .GetProperty(name: nameof(Flag.FlagCarrier))
            .SetValue(flag, player);

        // Act
        bool actual = flag.IsCaptured();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsCaptured_WhenFlagIsNotCapturedByPlayer_ShouldReturnsFalse()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Name = "Red",
            ColorHex = Color.Red
        };

        // Act
        bool actual = flag.IsCaptured();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void SetCarrier_WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Name = "Red",
            ColorHex = Color.Red
        };
        Player player = default;

        // Act
        Action act = () => flag.SetCarrier(player);

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(player));
    }

    [Test]
    public void RemoveCarrier_WhenNoPlayerHasCapturedFlag_ShouldNotThrowNullReferenceException()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Name = "Red",
            ColorHex = Color.Red
        };

        // Act
        Action act = flag.RemoveCarrier;

        // Assert
        act.Should().NotThrow<NullReferenceException>();
    }
}
