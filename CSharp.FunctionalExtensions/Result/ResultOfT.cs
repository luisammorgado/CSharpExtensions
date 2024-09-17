namespace CSharp.FunctionalExtensions;

/// <summary>
/// Represents a result of an operation that can either be a success or a failure.
/// </summary>
/// <typeparam name="TData">The type of the data in the result.</typeparam>
/// <typeparam name="TError">The type of the error in the result.</typeparam>
[ExcludeFromCodeCoverage]
public readonly struct Result<TData, TError>
{
    private readonly bool _success;

    private Result(TData value, TError error, bool success)
    {
        Data = value;
        Error = error;
        _success = success;
    }

    public bool IsSuccess() => _success;

    public bool IsFailure() => !IsSuccess();

    public TData Data { get; }

    public TError Error { get; }

    public R Match<R>(Func<TData, R> success, Func<TError, R> failure) => _success ? success(Data) : failure(Error);

    public static implicit operator Result<TData, TError>(TData value) => new(value, default!, true);

    public static implicit operator Result<TData, TError>(TError error) => new(default!, error, false);

    // Builders
    public static Result<TData, TError> Success(TData value) => new(value, default!, true);

    public static Result<TData, TError> Failure(TError error) => new(default!, error, false);

    public static Result<TData, ErrorResult> Failure(string message) => new(default!, ErrorResult.Create(message), false);

    public static Result<TData, ErrorResult> Exception(Exception ex) => new(default!, ErrorResult.Create($"Exception {ex.Message}"), false);
}