namespace CTF.Application.Tests.Players.Vitalities;

public class HealthArmourExtensionsTests
{
    [TestCase(50, 20, 70)]
    [TestCase(90, 10, 100)]
    [TestCase(80, 20, 100)]
    [TestCase(70, 10, 80)]
    [TestCase(100, 0, 100)]
    public void AddHealth_WhenAmountIsPositiveAndBelowLimit_ShouldIncreaseHealth(
        float currentHealth,
        float amount,
        float expectedHealth)
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Health = currentHealth
        };

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
        float amount = 20;
        float expectedHealth = 100;

        // Act
        player.AddHealth(amount);

        // Assert
        player.Health.Should().Be(expectedHealth);
    }

    [TestCase(50, -20, 70)]
    [TestCase(99, -1, 100)]
    [TestCase(98, -2, 100)]
    [TestCase(80, -20, 100)]
    [TestCase(70, -10, 80)]
    public void AddHealth_WhenAmountIsNegative_ShouldConvertToPositiveAndIncreaseHealth(
        float currentHealth,
        float amount,
        float expectedHealth)
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Health = currentHealth
        };

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
        float amount = 0;
        float expectedHealth = 50;

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
        float amount = 10;
        float expectedHealth = 100;

        // Act
        player.AddHealth(amount);

        // Assert
        player.Health.Should().Be(expectedHealth);
    }

    [TestCase(50, 20, 70)]
    [TestCase(90, 10, 100)]
    [TestCase(80, 20, 100)]
    [TestCase(70, 10, 80)]
    [TestCase(100, 0, 100)]
    public void AddArmour_WhenAmountIsPositiveAndBelowLimit_ShouldIncreaseArmour(
        float currentArmour,
        float amount,
        float expectedArmour)
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Armour = currentArmour
        };

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
        float amount = 20;
        float expectedArmour = 100;

        // Act
        player.AddArmour(amount);

        // Assert
        player.Armour.Should().Be(expectedArmour);
    }

    [TestCase(50, -20, 70)]
    [TestCase(99, -1, 100)]
    [TestCase(98, -2, 100)]
    [TestCase(80, -20, 100)]
    [TestCase(70, -10, 80)]
    public void AddArmour_WhenAmountIsNegative_ShouldConvertToPositiveAndIncreaseArmour(
        float currentArmour,
        float amount,
        float expectedArmour)
    {
        // Arrange
        var player = new FakePlayer(id: 1, name: "Bob")
        {
            Armour = currentArmour
        };

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
        float amount = 0;
        float expectedArmour = 50;

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
        float amount = 10;
        float expectedArmour = 100;

        // Act
        player.AddArmour(amount);

        // Assert
        player.Armour.Should().Be(expectedArmour);
    }
}
