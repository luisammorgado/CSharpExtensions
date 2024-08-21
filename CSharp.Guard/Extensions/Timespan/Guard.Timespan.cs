using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void TimeSpanLessThan(
        [NotNull] TimeSpan argument,
        string argumentName,
        TimeSpan min,
        string minArgumentName = "",
        string format = @"hh\:mm\:ss"
    )
    {
        var message = $"{argumentName} is not allowing less than {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString(format))}"; ;
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < min, exception);
    }

    [DebuggerStepThrough]
    public static void TimeSpanGreaterThan(
        [NotNull] TimeSpan argument,
        string argumentName,
        [NotNull] TimeSpan max,
        string maxArgumentName = "",
        string format = @"hh\:mm\:ss"
    )
    {
        var message = $"{argumentName} is not allowing more than {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument > max, exception);
    }

    [DebuggerStepThrough]
    public static void TimeSpanLessThanOrEqual(
        [NotNull] TimeSpan argument,
        string argumentName,
        [NotNull] TimeSpan min,
        string minArgumentName = "",
        string format = @"hh\:mm\:ss"
    )
    {
        var message = $"{argumentName} is not allowing less than or equals to {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument <= min, exception);
    }

    [DebuggerStepThrough]
    public static void TimeSpanGreaterThanOrEqual
        ([NotNull] TimeSpan argument,
        string argumentName,
        [NotNull] TimeSpan max,
        string maxArgumentName = "",
        string format = @"hh\:mm\:ss"
    )
    {
        var message = $"{argumentName} is not allowing greater than or equals to {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString(format))}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument >= max, exception);
    }

    [DebuggerStepThrough]
    public static void TimeSpanOutOfRange(
        [NotNull] TimeSpan argument,
        string argumentName,
        [NotNull] TimeSpan startRange,
        TimeSpan endRange
    )
    {
        var message = $"{argumentName} is out of range";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < startRange || argument > endRange, exception);
    }
}