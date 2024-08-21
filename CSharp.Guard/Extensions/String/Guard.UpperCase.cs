using System.Diagnostics;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void UpperCase(string argument, string argumentName) =>
        Guard.NotIsMatch(argument, argumentName, @"[A-Z]");
}