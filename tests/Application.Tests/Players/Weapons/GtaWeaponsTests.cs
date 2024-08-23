namespace CTF.Application.Tests.Players.Weapons;

public class GtaWeaponsTests
{
    [Test]
    public void GetById_WhenWeaponIdIsNotFound_ShouldReturnsFailureResult()
    {
        // Arrange
        Weapon weaponId = Weapon.Connect;
        string expectedMessage = Messages.WeaponNotFound;

        // Act
        Result<IWeapon> result = GtaWeapons.GetById(weaponId);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetById_WhenWeaponIdIsFound_ShouldReturnsSuccessResult()
    {
        // Arrange
        Weapon weaponId = Weapon.Knife;

        // Act
        Result<IWeapon> result = GtaWeapons.GetById(weaponId);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Id.Should().Be(weaponId);
    }

    [TestCase("")]
    [TestCase("  ")]
    [TestCase("Connect")]
    public void GetByName_WhenWeaponNameIsNotFound_ShouldReturnsFailureResult(string weaponName)
    {
        // Arrange
        string expectedMessage = Messages.WeaponNotFound;

        // Act
        Result<IWeapon> result = GtaWeapons.GetByName(weaponName);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetByName_WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        string weaponName = default;

        // Act
        Action act = () => GtaWeapons.GetByName(weaponName);

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(weaponName));
    }

    [TestCase("Knife")]
    [TestCase("KNIFE")]
    [TestCase("knife")]
    public void GetByName_WhenWeaponNameIsFound_ShouldReturnsSuccessResult(string weaponName)
    {
        // Arrange
        Weapon expectedWeaponId = Weapon.Knife;

        // Act
        Result<IWeapon> result = GtaWeapons.GetByName(weaponName);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Id.Should().Be(expectedWeaponId);
    }

    [TestCase(-1)]
    [TestCase(1000)]
    public void GetByIndex_WhenIndexIsInvalid_ShouldReturnsFailureResult(int index)
    {
        // Arrange
        string expectedMessage = Messages.InvalidWeapon;

        // Act
        Result<IWeapon> result = GtaWeapons.GetByIndex(index);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetByIndex_WhenIndexIsMax_ShouldReturnsFailureResult()
    {
        // Arrange
        int index = GtaWeapons.Count;
        string expectedMessage = Messages.InvalidWeapon;

        // Act
        Result<IWeapon> result = GtaWeapons.GetByIndex(index);

        // Asserts
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public void GetByIndex_WhenIndexIsValid_ShouldReturnsSuccessResult()
    {
        // Arrange
        int index = 0;
        Weapon expectedWeaponId = Weapon.Knife;

        // Act
        Result<IWeapon> result = GtaWeapons.GetByIndex(index);

        // Asserts
        result.IsSuccess.Should().BeTrue();
        result.Value.Id.Should().Be(expectedWeaponId);
    }
}
