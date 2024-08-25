namespace CTF.Application.Tests.Maps;

public class LoadTimeTests
{
    static readonly int[] ExpectedIntervalCases = [5, 4, 3, 2, 1, 0];
    private readonly LoadTime _loadTime;
    public LoadTimeTests()
    {
        static void OnLoadingMap() { }
        static void OnLoadedMap() { }
        _loadTime = new LoadTime(OnLoadingMap, OnLoadedMap);
    }

    [Test]
    public void Constructor_WhenOnLoadingMapIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        Action onLoadingMap = default;
        static void OnLoadedMap() { }

        // Act
        Action act = () => 
        {
            var loadTime = new LoadTime(onLoadingMap, OnLoadedMap);
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(onLoadingMap));
    }

    [Test]
    public void Constructor_WhenOnLoadedMapIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        Action onLoadedMap = default;
        static void OnLoadingMap() { }

        // Act
        Action act = () =>
        {
            var loadTime = new LoadTime(OnLoadingMap, onLoadedMap);
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(onLoadedMap));
    }

    [TestCaseSource(nameof(ExpectedIntervalCases))]
    public void Decrease_WhenIntervalIsNotEqualsToZero_ShouldContinueToDecrease(int expectedInterval)
    {
        // Arrange
        var expectedText = $"Loading map... ({expectedInterval})";

        // Act
        _loadTime.Decrease();
        int currentInterval = _loadTime.Interval;

        // Asserts
        currentInterval.Should().Be(expectedInterval);
        _loadTime.GameText.Should().Be(expectedText);
    }

    [Test]
    public void Decrease_WhenIntervalIsEqualsToZero_ShouldInvokeOnLoadedMap()
    {
        // Arrange
        static void OnLoadingMap() { }
        static void OnLoadedMap() => throw new Exception(nameof(OnLoadedMap));
        var loadTime = new LoadTime(OnLoadingMap, OnLoadedMap);
        loadTime.Decrease(); // 5
        loadTime.Decrease(); // 4
        loadTime.Decrease(); // 3
        loadTime.Decrease(); // 2
        loadTime.Decrease(); // 1
        loadTime.Decrease(); // 0

        // Act
        // Invoke to OnLoadedMap
        Action act = loadTime.Decrease;

        // Asserts
        act.Should()
           .Throw<Exception>()
           .WithMessage(nameof(OnLoadedMap));

        loadTime.Interval.Should().Be(LoadTime.MaxLoadTime);
        loadTime.GameText.Should().BeEmpty();
    }

    [Test]
    public void Decrease_WhenIntervalIsEqualsToMaxLoadTime_ShouldInvokeOnLoadingMap()
    {
        // Arrange
        static void OnLoadingMap() => throw new Exception(nameof(OnLoadingMap));
        static void OnLoadedMap() { }
        var loadTime = new LoadTime(OnLoadingMap, OnLoadedMap);

        // Act
        // Invoke to OnLoadingMap
        Action act = loadTime.Decrease;

        // Assert
        act.Should()
           .Throw<Exception>()
           .WithMessage(nameof(OnLoadingMap));
    }
}
