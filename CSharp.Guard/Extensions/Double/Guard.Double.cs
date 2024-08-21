﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void NumberLessThan(
        [NotNull] double argument,
        string argumentName,
        [NotNull] int min,
        string minArgumentName = ""
    )
    {
        var message = $"{argumentName} is not allowing less than {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString())}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < min, exception);
    }

    [DebuggerStepThrough]
    public static void NumberGreaterThan(
        [NotNull] double argument,
        string argumentName,
        [NotNull] int max,
        string maxArgumentName = ""
    )
    {
        var message = $"{argumentName} is not allowing more than {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString())}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument > max, exception);
    }

    [DebuggerStepThrough]
    public static void NumberLessThanOrEqual(
        [NotNull] double argument,
        string argumentName,
        [NotNull] int min,
        string minArgumentName = "")
    {
        var message = $"{argumentName} is not allowing less than or equals to {(!string.IsNullOrWhiteSpace(minArgumentName) ? minArgumentName : min.ToString())}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument <= min, exception);
    }

    [DebuggerStepThrough]
    public static void NumberGreaterThanOrEqual(
        [NotNull] double argument,
        string argumentName,
        [NotNull] int max,
        string maxArgumentName = ""
    )
    {
        var message = $"{argumentName} is not allowing greater than or equals to {(!string.IsNullOrWhiteSpace(maxArgumentName) ? maxArgumentName : max.ToString())}";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument >= max, exception);
    }

    [DebuggerStepThrough]
    public static void NumberZero(
        [NotNull] double argument,
        string argumentName
    )
    {
        var message = $"{argumentName} is not allowing 0";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument == 0, exception);
    }

    [DebuggerStepThrough]
    public static void NumberNegative(
        [NotNull] double argument,
        string argumentName
    )
    {
        var message = $"{argumentName} is not allowing negative value";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < 0, exception);
    }

    [DebuggerStepThrough]
    public static void NumberNegativeOrZero(
        [NotNull] double argument,
        string argumentName
    )
    {
        var message = $"{argumentName} is not allowing negative value or 0";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument <= 0, exception);
    }

    [DebuggerStepThrough]
    public static void NumberOutOfRange(
        [NotNull] double argument,
        string argumentName,
        [NotNull] int startRange,
        [NotNull] int endRange
    )
    {
        var message = $"{argumentName} is out of range";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument < startRange || argument > endRange, exception);
    }
}