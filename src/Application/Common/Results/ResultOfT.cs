namespace CTF.Application.Common.Results;

/// <summary>
/// Represents the result of an operation that returns a value.
/// </summary>
/// <typeparam name="TValue">A value associated to the result.</typeparam>
public ref struct Result<TValue>
{
    private TValue _value;
    public Result() { }

    /// <summary>
    /// Gets the value associated with the result.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// when <see cref="Result.IsFailed"/> is true.
    /// </exception>
    public TValue Value
    {
        get
        {
            return IsSuccess ?
                _value :
                throw new InvalidOperationException("The value of a failure result can not be accessed.");
        }
        private set
        {
            _value = value;
        }
    }

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

    public static Result<TValue> Success(TValue value) => new() 
    { 
        IsSuccess = true,
        Value = value 
    };

    public static Result<TValue> Success(TValue value, string message) => new()
    {
        IsSuccess = true,
        Value = value,
        Message = message
    };

    public static Result<TValue> Failure() => new();
    public static Result<TValue> Failure(string message) => new() { Message = message };
}
