using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void True(
        bool argument,
        [NotNull] string argumentName
    )
    {
        var message = $"{argumentName} is not allowing to be true";
        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument == true, exception);
    }

    [DebuggerStepThrough]
    public static void False(
        bool argument,
        [NotNull] string argumentName
    )
    {
        var message = $"{argumentName} is not allowing to be false";

        var exception = CreateException<ArgumentException>(message);

        Guard.For(() => argument == false, exception);
    }
}