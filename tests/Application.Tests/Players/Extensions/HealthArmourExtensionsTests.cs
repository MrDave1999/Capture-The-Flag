namespace CTF.Application.Tests.Players.Extensions;

public class HealthArmourExtensionsTests
{
    [Test]
    public void AddHealth_WhenAmountIsPositiveAndBelowLimit_ShouldIncreaseHealth()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Health = 50
        };
        int amount = 20;
        int expectedHealth = 70;

        // Act
        player.AddHealth(amount);

        // Assert
        player.Health.Should().Be(expectedHealth);
    }

    [Test]
    public void AddHealth_WhenAmountIsPositiveAndExceedsLimit_ShouldSetHealthToMax()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Health = 90
        };
        int amount = 20;
        int expectedHealth = 100;

        // Act
        player.AddHealth(amount);

        // Assert
        player.Health.Should().Be(expectedHealth);
    }

    [Test]
    public void AddHealth_WhenAmountIsNegative_ShouldConvertToPositiveAndIncreaseHealth()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Health = 50
        };
        int amount = -20;
        int expectedHealth = 70;

        // Act
        player.AddHealth(amount);

        // Assert
        player.Health.Should().Be(expectedHealth);
    }

    [Test]
    public void AddHealth_WhenAmountIsZero_ShouldNotChangeHealth()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Health = 50
        };
        int amount = 0;
        int expectedHealth = 50;

        // Act
        player.AddHealth(amount);

        // Assert
        player.Health.Should().Be(expectedHealth);
    }

    [Test]
    public void AddHealth_WhenPlayerHasMaxHealth_ShouldNotChangeHealth()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Health = 100
        };
        int amount = 10;
        int expectedHealth = 100;

        // Act
        player.AddHealth(amount);

        // Assert
        player.Health.Should().Be(expectedHealth);
    }

    [Test]
    public void AddArmour_WhenAmountIsPositiveAndBelowLimit_ShouldIncreaseArmour()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Armour = 50
        };
        int amount = 20;
        int expectedArmour = 70;

        // Act
        player.AddArmour(amount);

        // Assert
        player.Armour.Should().Be(expectedArmour);
    }

    [Test]
    public void AddArmour_WhenAmountIsPositiveAndExceedsLimit_ShouldSetArmourToMax()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Armour = 90
        };
        int amount = 20;
        int expectedArmour = 100;

        // Act
        player.AddArmour(amount);

        // Assert
        player.Armour.Should().Be(expectedArmour);
    }

    [Test]
    public void AddArmour_WhenAmountIsNegative_ShouldConvertToPositiveAndIncreaseArmour()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Armour = 50
        };
        int amount = -20;
        int expectedArmour = 70;

        // Act
        player.AddArmour(amount);

        // Assert
        player.Armour.Should().Be(expectedArmour);
    }

    [Test]
    public void AddArmour_WhenAmountIsZero_ShouldNotChangeArmour()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Armour = 50
        };
        int amount = 0;
        int expectedArmour = 50;

        // Act
        player.AddArmour(amount);

        // Assert
        player.Armour.Should().Be(expectedArmour);
    }

    [Test]
    public void AddArmour_WhenPlayerHasMaxArmour_ShouldNotChangeArmour()
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Armour = 100
        };
        int amount = 10;
        int expectedArmour = 100;

        // Act
        player.AddArmour(amount);

        // Assert
        player.Armour.Should().Be(expectedArmour);
    }
}
