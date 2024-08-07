namespace CTF.Application.Common;

/// <summary>
/// Represents the result of an operation that returns a value.
/// </summary>
/// <typeparam name="TValue">A value associated to the result.</typeparam>
internal readonly ref struct Result<TValue>
{
    public Result() { }

    /// <summary>
    /// Gets the value associated with the result.
    /// </summary>
    public TValue Value { get; init; } = default;

    /// <summary>
    /// Gets the description of a result.
    /// </summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>
    /// A value indicating that the result was successful.
    /// </summary>
    public bool IsSuccess { get; init; } = true;

    /// <summary>
    /// A value that indicates that the result was a failure.
    /// </summary>
    public bool IsFailed => !IsSuccess;

    public static Result<TValue> Success(TValue value) => new() { Value = value };
    public static Result<TValue> Success(TValue value, string message) => new()
    {
        Value = value,
        Message = message
    };

    public static Result<TValue> Failure() => new() { IsSuccess = false };
    public static Result<TValue> Failure(string message) => new()
    {
        IsSuccess = false,
        Message = message
    };
}
