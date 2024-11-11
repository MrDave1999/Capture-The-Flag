namespace CTF.Application.Tests.Players.Weapons;

public class WeaponTests
{
    [Test]
    public void Is_WhenWeaponIsEqualToKnife_ShouldReturnsTrue()
    {
        // Arrange
        Result<IWeapon> result = GtaWeapons.GetById(Weapon.Knife);
        IWeapon weapon = result.Value;

        // Act
        bool actual = weapon.Is(Weapon.Knife);

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void Is_WhenWeaponIsNotEqualToKnife_ShouldReturnsFalse()
    {
        // Arrange
        Result<IWeapon> result = GtaWeapons.GetById(Weapon.Knife);
        IWeapon weapon = result.Value;

        // Act
        bool actual = weapon.Is(Weapon.Deagle);

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void IsNot_WhenWeaponIsNotEqualToKnife_ShouldReturnsTrue()
    {
        // Arrange
        Result<IWeapon> result = GtaWeapons.GetById(Weapon.Knife);
        IWeapon weapon = result.Value;

        // Act
        bool actual = weapon.IsNot(Weapon.Deagle);

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsNot_WhenWeaponIsEqualToKnife_ShouldReturnsFalse()
    {
        // Arrange
        Result<IWeapon> result = GtaWeapons.GetById(Weapon.Knife);
        IWeapon weapon = result.Value;

        // Act
        bool actual = weapon.IsNot(Weapon.Knife);

        // Assert
        actual.Should().BeFalse();
    }
}
