using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void DateTimeOffsetLessThan(
        [NotNull] DateTimeOffset argument,
        string argumentName,
        [NotNull] DateTimeOffset min,
        string minArgumentName = "",
        string format = "dd/MM/yyyy"
    )
    {
        var message = $"{argumentName} is not allowing less than or equals to {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < min, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeOffsetGreaterThan(
        [NotNull] DateTimeOffset argument,
        string argumentName,
        [NotNull] DateTimeOffset max,
        string maxArgumentName = "",
        string format = "dd/MM/yyyy"
    )
    {
        var message = $"{argumentName} is not allowing greater than or equals to {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument > max, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeOffsetLessThanOrEqual(
        [NotNull] DateTimeOffset argument,
        string argumentName,
        [NotNull] DateTimeOffset min,
        string minArgumentName = "",
        string format = "dd/MM/yyyy"
    )
    {
        var message = $"{argumentName} is not allowing less than or equals to {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument <= min, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeOffsetGreaterThanOrEqual(
        [NotNull] DateTimeOffset argument,
        string argumentName,
        [NotNull] DateTimeOffset max,
        string maxArgumentName = "",
        string format = "dd/MM/yyyy"
    )
    {
        var message = $"{argumentName} is not allowing greater than or equals to {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument <= max, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeOffsetOutOfRange(
        [NotNull] DateTimeOffset argument,
        string argumentName,
        [NotNull] DateTimeOffset startRange,
        [NotNull] DateTimeOffset endRange
    )
    {
        var message = $"{argumentName} is out of range";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < startRange || argument > endRange, exception);
    }
}