namespace CTF.Application.Tests.Players.Weapons;

public class WeaponPackTests
{
    [Test]
    public void IsEmpty_WhenThereAreNoDefaultWeapons_ShouldReturnsTrue()
    {
        // Arrange
        var weapons = new WeaponPack();
        weapons.Clear();

        // Act
        bool actual = weapons.IsEmpty();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsEmpty_WhenThereAreDefaultWeapons_ShouldReturnsFalse()
    {
        // Arrange
        var weapons = new WeaponPack();

        // Act
        bool actual = weapons.IsEmpty();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void Add_WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var weapons = new WeaponPack();
        IWeapon weapon = default;

        // Act
        Action act = () => weapons.Add(weapon);

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(weapon));
    }

    [Test]
    public void Add_WhenThereIsWeaponWithSameCategoryOrSlot_ShouldReplaceExistingWeapon()
    {
        // Arrange
        var weapons = new WeaponPack();
        // These two weapons are of the same category/slot.
        IWeapon existingWeapon = GtaWeapons.GetById(Weapon.Shotgun).Value;
        weapons.Add(existingWeapon);
        IWeapon newWeapon = GtaWeapons.GetById(Weapon.CombatShotgun).Value;

        // Act
        weapons.Add(newWeapon);

        // Asserts
        weapons.Exists(existingWeapon).Should().BeFalse();
        weapons.Exists(newWeapon).Should().BeTrue();
    }

    [Test]
    public void Add_WhenNewWeaponIsNotOfTheSameCategoryOrSlot_ShouldNotReplaceExistingWeapon()
    {
        // Arrange
        var weapons = new WeaponPack();
        // These two weapons are not of the same category/slot.
        IWeapon existingWeapon = GtaWeapons.GetById(Weapon.Shotgun).Value;
        weapons.Add(existingWeapon);
        IWeapon newWeapon = GtaWeapons.GetById(Weapon.AK47).Value;

        // Act
        weapons.Add(newWeapon);

        // Asserts
        weapons.Exists(existingWeapon).Should().BeTrue();
        weapons.Exists(newWeapon).Should().BeTrue();
    }

    [Test]
    public void Exists_WhenWeaponIsFound_ShouldReturnsTrue()
    {
        // Arrange
        var weapons = new WeaponPack();
        IWeapon deagle = GtaWeapons.GetById(Weapon.Deagle).Value;

        // Act
        bool actual = weapons.Exists(deagle);

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void Exists_WhenWeaponIsNotFound_ShouldReturnsFalse()
    {
        // Arrange
        var weapons = new WeaponPack();
        IWeapon ak47 = GtaWeapons.GetById(Weapon.AK47).Value;

        // Act
        bool actual = weapons.Exists(ak47);

        // Assert
        actual.Should().BeFalse();
    }
}
