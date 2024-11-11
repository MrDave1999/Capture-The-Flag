namespace CTF.Application.Common.Results;

/// <summary>
/// Represents the result of an operation that does not return a value.
/// </summary>
public ref struct Result
{
    public Result() { }

    /// <summary>
    /// Gets the description of a result.
    /// </summary>
    public string Message { get; private set; } = string.Empty;

    /// <summary>
    /// A value indicating that the result was successful.
    /// </summary>
    public bool IsSuccess { get; private set; } = false;

    /// <summary>
    /// A value that indicates that the result was a failure.
    /// </summary>
    public bool IsFailed => !IsSuccess;

    public static Result Success() => new() { IsSuccess = true };
    public static Result Success(string message) => new() 
    { 
        IsSuccess = true,
        Message = message 
    };

    public static Result Failure() => new();
    public static Result Failure(string message) => new() { Message = message };
}
