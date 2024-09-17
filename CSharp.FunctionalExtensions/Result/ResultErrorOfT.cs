namespace CSharp.FunctionalExtensions;

/// <summary>
/// Represents a result error with a specific error type.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class ResultError<TError>
{
    private ResultError(TError error) => Error = error;

    /// <summary>
    /// Gets the error value.
    /// </summary>
    public TError Error { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ResultError{TError}" /> with the specified error value.
    /// </summary>
    /// <param name="error">The error value.</param>
    /// <returns>A new instance of <see cref="ResultError{TError}" />.</returns>
    public static ResultError<TError> Create(TError error) => new(error);

    /// <summary>
    /// Creates a new instance of <see cref="ResultError{TError}" /> with an error result
    /// representing the specified exception.
    /// </summary>
    /// <param name="ex">The exception.</param>
    /// <returns>
    /// A new instance of <see cref="ResultError{TError}" /> with an error result representing the exception.
    /// </returns>
    public static ResultError<ErrorResult> Exception(Exception ex) => new(ErrorResult.Create($"Exception {ex.Message}"));
}