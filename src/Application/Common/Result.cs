namespace CTF.Application.Common;

/// <summary>
/// Represents the result of an operation that does not return a value.
/// </summary>
public readonly ref struct Result
{
    public Result() { }

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

    public static Result Success() => new();
    public static Result Success(string message) => new() { Message = message };

    public static Result Failure() => new() { IsSuccess = false };
    public static Result Failure(string message) => new()
    {
        IsSuccess = false,
        Message = message
    };
}
