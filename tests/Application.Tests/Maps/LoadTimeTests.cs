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
    public void Decrease_WhenLoadTimeIsNotCompleted_ShouldContinueToDecrease(int expectedInterval)
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
        bool loadedMap = false;
        static void OnLoadingMap() { }
        void OnLoadedMap() => loadedMap = true;
        var loadTime = new LoadTime(OnLoadingMap, OnLoadedMap);
        int expectedInterval = LoadTime.MaxLoadTime;
        loadTime.Decrease(); // 5
        loadTime.Decrease(); // 4
        loadTime.Decrease(); // 3
        loadTime.Decrease(); // 2
        loadTime.Decrease(); // 1
        loadTime.Decrease(); // 0

        // Act
        // Invoke to OnLoadedMap
        loadTime.Decrease();

        // Asserts
        loadedMap.Should().BeTrue();
        loadTime.Interval.Should().Be(expectedInterval);
        loadTime.GameText.Should().BeEmpty();
    }

    [Test]
    public void Decrease_WhenIntervalIsEqualsToMaxLoadTime_ShouldInvokeOnLoadingMap()
    {
        // Arrange
        bool loadingMap = false;
        void OnLoadingMap() => loadingMap = true;
        static void OnLoadedMap() { }
        var loadTime = new LoadTime(OnLoadingMap, OnLoadedMap);
        int expectedInterval = 5;

        // Act
        // Invoke to OnLoadingMap
        loadTime.Decrease();

        // Asserts
        loadingMap.Should().BeTrue();
        loadTime.Interval.Should().Be(expectedInterval);
        loadTime.GameText.Should().NotBeEmpty();
    }
}
