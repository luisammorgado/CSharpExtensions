namespace CSharp.FunctionalExtensions;

/// <summary>
/// Represents an error result record.
/// </summary>
/// <param name="message"></param>
[ExcludeFromCodeCoverage]
public readonly struct ErrorResult(string message)
{
    public string Message { get; } = message;

    public static ErrorResult Create(string message) => new(message);
}