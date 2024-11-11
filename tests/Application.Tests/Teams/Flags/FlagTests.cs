namespace CTF.Application.Tests.Teams.Flags;

public class FlagTests
{
    [Test]
    public void IsCaptured_WhenFlagIsCapturedByPlayer_ShouldReturnsTrue()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Icon = FlagIcon.Red,
            Name = "Red",
            ColorHex = Color.Red
        };
        var fakeCarrier = new FakeCarrier();
        flag.SetCarrier(fakeCarrier);

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
            Icon = FlagIcon.Red,
            Name = "Red",
            ColorHex = Color.Red
        };

        // Act
        bool actual = flag.IsCaptured();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void CarrierName_WhenFlagIsCaptured_ShouldReturnsCarrierName()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Blue,
            Icon = FlagIcon.Blue,
            Name = "Blue",
            ColorHex = Color.Blue
        };
        var expectedCarrierName = "Bob";
        var fakeCarrier = new FakePlayer(id: 1, expectedCarrierName);
        flag.SetCarrier(fakeCarrier);

        // Act
        string actual = flag.CarrierName;

        // Assert
        actual.Should().Be(expectedCarrierName);
    }

    [Test]
    public void CarrierName_WhenFlagIsNotCaptured_ShouldReturnsNone()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Blue,
            Icon = FlagIcon.Blue,
            Name = "Blue",
            ColorHex = Color.Blue
        };
        var expectedCarrierName = "None";

        // Act
        string actual = flag.CarrierName;

        // Assert
        actual.Should().Be(expectedCarrierName);
    }

    [Test]
    public void SetCarrier_WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Icon = FlagIcon.Red,
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
    public void SetCarrier_WhenArgumentIsValid_ShouldSetPlayerAsCarrier()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Icon = FlagIcon.Red,
            Name = "Red",
            ColorHex = Color.Red
        };
        var fakeCarrier = new FakeCarrier();

        // Act
        flag.SetCarrier(fakeCarrier);

        // Assert
        flag.Carrier.Should().Be(fakeCarrier);
    }

    [Test]
    public void RemoveCarrier_WhenNoPlayerHasCapturedFlag_ShouldNotThrowNullReferenceException()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Icon = FlagIcon.Red,
            Name = "Red",
            ColorHex = Color.Red
        };

        // Act
        Action act = flag.RemoveCarrier;

        // Assert
        act.Should().NotThrow<NullReferenceException>();
    }

    [Test]
    public void RemoveCarrier_WhenPlayerHasCapturedFlag_ShouldRemoveFlagOfThatPlayer()
    {
        // Arrange
        var flag = new Flag
        {
            Model = FlagModel.Red,
            Icon = FlagIcon.Red,
            Name = "Red",
            ColorHex = Color.Red
        };
        var fakeCarrier = new FakeCarrier();
        flag.SetCarrier(fakeCarrier);

        // Act
        flag.RemoveCarrier();

        // Assert
        flag.Carrier.Should().BeNull();
    }
}
