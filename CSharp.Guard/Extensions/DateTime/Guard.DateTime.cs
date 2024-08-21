using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void DateTimeLessThan(
        [NotNull] DateTime argument,
        string argumentName,
        [NotNull] DateTime min,
        string minArgumentName = "",
        string format = "dd/MM/yyyy"
    )
    {
        var message = $"{argumentName} is not allowing less than {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < min, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeGreaterThan(
        [NotNull] DateTime argument,
        string argumentName,
        [NotNull] DateTime max,
        string maxArgumentName = "", string format = "dd/MM/yyyy")
    {
        var message = $"{argumentName} is not allowing more than {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument > max, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeLessThanOrEqual(
        [NotNull] DateTime argument,
        string argumentName,
        [NotNull] DateTime min,
        string minArgumentName = "",
        string format = "dd/MM/yyyy"
    )
    {
        var message = $"{argumentName} is not allowing less than or equals to {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument <= min, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeGreaterThanOrEqual(
        [NotNull] DateTime argument,
        string argumentName,
        [NotNull] DateTime max,
        string maxArgumentName = "",
        string format = "dd/MM/yyyy"
    )
    {
        var message = $"{argumentName} is not allowing greater than or equals to {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument >= max, exception);
    }

    [DebuggerStepThrough]
    public static void DateTimeOutOfRange(
        [NotNull] DateTime argument,
        string argumentName,
        [NotNull] DateTime startRange,
        [NotNull] DateTime endRange
    )
    {
        var message = $"{argumentName} is out of range";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < startRange || argument > endRange, exception);
    }
}